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
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Velocity.y = jumpspeed * Time.deltaTime;
            transform.Translate(Velocity);
            grounded = false;

        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Velocity.x = movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Velocity.x = -movementSpeed * Time.deltaTime;
        }
        else
        {
            Velocity.x = 0.0f; //to set velocity to zero when no key is pressed.
        }

        if (!grounded)
        {

            Velocity.y += (Physics2D.gravity.y * gravitymodifier * Time.deltaTime);
        }



        if (Physics2D.Raycast((Vector2)transform.position + (Vector2.down * 0.7f), Vector2.down, 0.1f) && !grounded && Velocity.y<=0)
        {
            grounded = true;
            Velocity.y = 0.0f; // to stop speed in vertical direction.
        }

        transform.Translate(Velocity);
    }


}
