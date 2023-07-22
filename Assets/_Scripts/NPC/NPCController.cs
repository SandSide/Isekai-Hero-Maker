using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCController : HoverableItem
{
    public static float speed = 1f;
    public float maxChangeDirectionInterval = 8f;
    public float currentChangeInterval;
    public Vector2 targetDirection;
    public bool canMove = false;

    public Person npcDetails;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            currentChangeInterval -= Time.deltaTime;
           
            if(currentChangeInterval < 0)
            {
                currentChangeInterval = Random.Range(2, maxChangeDirectionInterval + 1);
                targetDirection = Random.onUnitSphere*10;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetDirection, speed * Time.deltaTime);
        }
    }

    public void Init()
    {
        currentChangeInterval = Random.Range(2, maxChangeDirectionInterval + 1);
        targetDirection = Random.onUnitSphere*10;
        canMove = true;
    }

    public void Init(Person person)
    {
        npcDetails = person;
        currentChangeInterval = Random.Range(2, maxChangeDirectionInterval + 1);
        targetDirection = Random.onUnitSphere*10;
        canMove = true;
    }

    public void Die()
    {
        QuestController.Instance.EvaluateQuestResult(npcDetails);
        AudioManager.instance.PlaySimultaneous("kill");
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Environment") || col.gameObject.CompareTag("NPC"))
        {
            targetDirection = -targetDirection;
            // targetDirection = Random.onUnitSphere*10;
        }
    }

    public override void OnHover()
    {
        UIManager.Instance.UpdateNPCDetails(npcDetails);
        UIManager.Instance.ToggleUIElement(UIManager.Instance.npcDetailsUI, true);
    }

    public override void OnHoverExit()
    {
        UIManager.Instance.ToggleUIElement(UIManager.Instance.npcDetailsUI, false);
    }

    public void OnMouseEnter()
    {
        OnHover();
    }

    // public void OnMouseExit()
    // {
    //     OnHoverExit();
    // }
}
