using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded = false;
    public float jumpforce;
    public float movementSpeed;
    private Rigidbody2D Pico;
    private float inputX,inputY;

    // Start is called before the first frame update
    void Start()
    {
        Pico = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        if (!grounded)
        {
            transform.Translate(Physics2D.gravity*Time.deltaTime);
        }

        if (Physics2D.Raycast((Vector2)transform.position + (Vector2.down * 0.7f) , Vector2.down,0.1f) && !grounded)
        { 
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Pico.isKinematic = false;
            Pico.AddForce(Vector2.up * jumpforce);
            Pico.isKinematic = true;
            grounded = false;

        }


    }


}
