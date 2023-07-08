using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckController : MonoBehaviour
{

    //public int speed = 0;
    public float maxSpeed = 1;
    public float turnRate = 1f;

    Rigidbody2D rb;

    public float currentSpeed = 0f;
    public float acelerationRate = 2f;
    public float decelerationRate = 2f;
    private bool moveForward = false;

    Vector2 moveDirection = Vector2.right;

    private bool rotate = false;
    private float currentTurnRate = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
    
        //moveDirection

        rb.velocity = transform.right * currentSpeed;
        
        //new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);

        // rb.AddForce(transform.right * currentSpeed * Time.deltaTime, ForceMode2D.Force);

        if( rotate)
        {
            transform.Rotate(Vector3.forward * currentTurnRate * Time.deltaTime);
        }
    
    }


    public void HandleInput()
    {

        if(Input.GetKey(KeyCode.W))
        {
            currentSpeed += acelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            moveForward = true;
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            moveForward = false;
        }

        if(!moveForward)
        {
            currentSpeed -= decelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f);
        }




        if(Input.GetKey(KeyCode.A))
        {
            currentTurnRate = turnRate;
            rotate = true;
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            currentTurnRate = 0f;
            rotate = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            currentTurnRate = -turnRate;
            rotate = true;
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            currentTurnRate = 0f;
            rotate = false;
        }


    }

    public void Move()
    {

    }
}
