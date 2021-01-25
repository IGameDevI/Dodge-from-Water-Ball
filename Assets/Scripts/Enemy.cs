using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    private float speed;
    private Player playerScript;
    public GameObject particle;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed,maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (hitObject.tag == "Finish")
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}
