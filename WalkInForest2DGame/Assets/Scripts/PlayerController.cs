using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded = false;
    public float gravitymodifier = 1f;
    public float jumpforce;
    public float movementSpeed;
    private Rigidbody2D Pico;
    private float inputX,inputY;

    // Start is called before the first frame update
    void Start()
    {
        Pico = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            transform.Translate(Vector2.up * jumpforce * Time.deltaTime);
            grounded = false;

        }

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
            transform.Translate(Physics2D.gravity * gravitymodifier * Time.deltaTime);
        }

        if (Physics2D.Raycast((Vector2)transform.position + (Vector2.down * 0.7f) , Vector2.down,0.1f) && !grounded)
        { 
            grounded = true;
        }



    }


}
