using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //public float speed;

    public GameObject player;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);



        /*
        if (transform.position.x < 7 && transform.position.x >= -7 && transform.position.y < 0)
        {
            
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.y < 3 && transform.position.y >= -3 && transform.position.x > 0)
        {
            
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        else if (transform.position.x <= 7 && transform.position.x > -7 && transform.position.y > 0)
        {
            
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        else if (transform.position.y <= 3 && transform.position.y > -3 && transform.position.x < 0)
        {
            
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.x > 7)
        {
            transform.position = new Vector2(7, -3);
        }

        else if (transform.position.y > 3)
        {
            transform.position = new Vector2(7, 3);
        }

        else if (transform.position.x < -7)
        {
            transform.position = new Vector2(-7, 3);
        }

        else if (transform.position.x < -3)
        {
            transform.position = new Vector2(-7, -3);
        }

        */

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {

            player.Die();

        }
    }

}
