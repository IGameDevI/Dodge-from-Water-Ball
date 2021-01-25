using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    private float runHorizontal;
    private GameObject player;

    public byte health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        anim.SetBool("isRunning", runHorizontal != 0);
        if (runHorizontal >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 
        else if (runHorizontal < 0)
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
        runHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(runHorizontal * speed, rb.velocity.y);
    }

    public void TakeDamage(byte damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(player);
        }
    }
}
