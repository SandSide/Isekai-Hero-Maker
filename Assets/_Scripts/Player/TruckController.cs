using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckController : MonoBehaviour
{

    //public int speed = 0;
    public float maxSpeed = 1;
    public float maxReverseSpeed = 1;
    public float turnRate = 1f;
    public float acelerationRate = 2f;
    public float slowRate = 2f;

    Rigidbody2D rb;

    public float currentSpeed = 0f;
    private bool moveForward = false;
    private bool reverse = false;
    private bool rotate = false;

    private float currentTurnRate = 0f;

    Vector2 moveDirection = Vector2.right;

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
    
        rb.velocity = transform.right * currentSpeed;
        
        if( rotate)
        {
            transform.Rotate(Vector3.forward * currentTurnRate * Time.deltaTime);
        }
    
    }


    public void HandleInput()
    {

        // Forward
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

        // Reverse
        if(Input.GetKey(KeyCode.S))
        {
           currentSpeed -= acelerationRate * Time.deltaTime;
           currentSpeed = Mathf.Max(currentSpeed, -maxReverseSpeed);

            reverse = true;
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            reverse = false;
        }



        if(!moveForward && !reverse)
        {
            if(currentSpeed > 0)
            {
                currentSpeed -= slowRate * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0f);
            }
            else 
            {
                currentSpeed += slowRate * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, 0f);
            }
        }



        // Turning
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
