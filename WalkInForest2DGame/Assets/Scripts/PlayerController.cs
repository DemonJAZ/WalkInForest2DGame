using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded = false;
    public float gravitymodifier = 1f;
    public float jumpspeed = 1f;
    public float movementSpeed;
    private Vector2 Velocity;
    private Rigidbody2D Pico;



    // Start is called before the first frame update
    void Start()
    {
        Pico = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        Debug.DrawRay(Pico.position + new Vector2(0.3f,-0.6f), Vector2.down*0.1f,Color.red);
        Debug.DrawRay(Pico.position + new Vector2(-0.3f,-0.6f), Vector2.down * 0.1f, Color.red);
        Debug.DrawRay(Pico.position + new Vector2(0f, -0.7f), Vector2.down * 0.1f, Color.red);

        Debug.DrawRay(Pico.position + new Vector2(0.34f, 0.6f), Vector2.right * 0.1f, Color.red);
        Debug.DrawRay(Pico.position + new Vector2(0.34f, 0f), Vector2.right * 0.1f, Color.red);
        Debug.DrawRay(Pico.position + new Vector2(0.34f, -0.6f), Vector2.right * 0.1f, Color.red);


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Velocity.y = jumpspeed * Time.deltaTime;
            grounded = false;
            transform.Translate(Velocity);

        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        { 
            Velocity.x = -movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Velocity.x = movementSpeed * Time.deltaTime;
        }
        else
        {
            Velocity.x = Vector2.zero.x;
        }

        if ( (Velocity.x != 0.0f) && HorizontalCollision() )
        {
            Velocity.x = Vector2.zero.x;
        }

        if (!grounded)
        {
            Velocity.y += Physics2D.gravity.y * gravitymodifier * Time.deltaTime;
        }

        if (VerticalCollisions() && !grounded)
        {
            Velocity.y = 0;
            grounded = true;
        }


        transform.Translate(Velocity);
    }

    private bool VerticalCollisions()
    {
        return Physics2D.Raycast(Pico.position + new Vector2(0.3f, -0.6f), Vector2.down, 0.1f) ||
                Physics2D.Raycast(Pico.position + new Vector2(-0.3f, -0.6f), Vector2.down, 0.1f) ||
                Physics2D.Raycast(Pico.position + new Vector2(0f, -0.7f), Vector2.down, 0.1f);
    }
    private bool HorizontalCollision()
    {
        float directionX = Mathf.Sign(Velocity.x);
        bool v = (directionX == -1.0f);
        Vector2 castDirection = v ? Vector2.left : Vector2.right;

        return Physics2D.Raycast(Pico.position + new Vector2(directionX *.34f, -0.6f), castDirection, 0.1f) ||
                Physics2D.Raycast(Pico.position + new Vector2(directionX * 0.34f, -0.6f), castDirection, 0.1f) ||
                Physics2D.Raycast(Pico.position + new Vector2(directionX * 0.34f, -0.7f), castDirection, 0.1f);
    }
}
