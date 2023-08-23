using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCController : HoverableItem, IClickable
{
    [SerializeField] 
    public Material onClickMaterial;
    public Material defaultMaterial;
    public Shader onClickShader;
    public Shader defaultShader;

    [Header("Stats")]
    public static float speed = 1f;
    public float maxChangeDirectionInterval = 8f;
    public float currentChangeInterval;
    private Vector2 targetDirection;
    public bool canMove = false;

    public Person npcDetails;
    
    Rigidbody2D rb;

    public bool IsClicked { get; set; } = false;

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
        GameEvents.Instance.NPCDied(this);
        AudioManager.instance.Play("kill");
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Environment") || col.gameObject.CompareTag("NPC"))
        {
            targetDirection = -targetDirection;
        }
    }

    public override void OnHover()
    {
        GameEvents.Instance.DisplayPersonChange(npcDetails);
        AddOutline();
    }

    public override void OnHoverExit()
    {
        ClickManager.Instance.ShowCurrentNPC();
        RemoveOutline();
    }

    public void OnClick()
    {
        IsClicked = true;
        GameEvents.Instance.DisplayPersonChange(npcDetails);
        AddOutline();
    }

    public void OnClickExit()
    {
        IsClicked = false;
        UIManager.Instance.ToggleUIElement(UIManager.Instance.npcDetailsUI, false);
        RemoveOutline();
    }

    public void AddOutline()
    {
        GetComponent<Renderer>().material = onClickMaterial;
        GetComponent<Renderer>().material.shader = onClickShader;
    }

    public void RemoveOutline()
    {
        if(!IsClicked)
        {
            GetComponent<Renderer>().material = defaultMaterial;
            GetComponent<Renderer>().material.shader = defaultShader;
        }
    }
}
