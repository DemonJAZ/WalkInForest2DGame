using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        if (!grounded)
        {
            transform.Translate(Vector2.down * 3f * Time.deltaTime);
        }

        if (!Physics2D.Raycast(gameObject.transform.position, Vector2.down, 3f))
        {
            grounded = true;
        }
    }


}
