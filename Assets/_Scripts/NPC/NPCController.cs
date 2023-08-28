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
                targetDirection = GetNewDirection();
            }

            //transform.position = Vector3.MoveTowards(transform.position, targetDirection, speed * Time.deltaTime);
            transform.position += (Vector3)targetDirection * speed * Time.deltaTime;
        }
    }

    public void Init()
    {
        currentChangeInterval = Random.Range(2, maxChangeDirectionInterval + 1);
        targetDirection  = GetNewDirection();
        canMove = true;
    }

    public void Init(Person person)
    {
        npcDetails = person;
        currentChangeInterval = Random.Range(2, maxChangeDirectionInterval + 1);
        targetDirection = GetNewDirection();
        canMove = true;
    }

    public void Die()
    {
        GameEvents.Instance.NPCDied(this);
        AudioManager.instance.Play("kill");
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Environment") || col.gameObject.CompareTag("NPC"))
        {
            targetDirection = GetNewDirection();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Environment") || col.gameObject.CompareTag("NPC"))
        {
            targetDirection = GetNewDirection();
        }
    }

    public Vector2 GetNewDirection()
    {
        float[] angles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f };
        //angles.

        foreach (float angle in angles)
        {
            // Calculate the direction vector based on the angle
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            // Cast a ray in the current direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 5f);

            if (!hit.collider.gameObject.CompareTag("Environment") && !hit.collider.gameObject.CompareTag("NPC"))
                return direction;
        }


        return Random.insideUnitCircle.normalized;

    }

    void OnDrawGizmos()
    {
        Vector2 temp = transform.position;

        // float[] angles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f };

        // foreach (float angle in angles)
        // {
        //     // Calculate the direction vector based on the angle
        //     Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        //     Gizmos.DrawRay(transform.position, direction);
        // }

        //Gizmos.DrawLine(transform.position, temp + targetDirection.normalized * maxChangeDirectionInterval * speed);
        Gizmos.DrawRay(transform.position, targetDirection);
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
