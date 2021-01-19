using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    private float input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("isRunning", input != 0);
        if (input >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (Input.GetKeyDown("space"))
        {
            transform.position = new Vector3();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }
}
