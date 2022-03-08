using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : MonoBehaviour
{

    public GameObject player;

    private Rigidbody2D rb;

    public float speed = 5;

    private float timer;
    public float time;


    Vector2 xy;
    //Vector2 y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Tilemap.GetComponent<Collider2D>(), false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if ("Room " + player.GetComponent<PlayerController>().CurrentRoom == transform.parent.parent.name)
        {
            
            xy = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            if (timer >= time && timer <= time + 0.25)
            {

                rb.velocity = new Vector2(xy.x * speed, (xy.y * speed));


            }

            else if (timer >= time + 0.25)
            {
                rb.velocity = new Vector2(0, 0);
                timer = 0;

            }

            timer += Time.deltaTime;
        }

        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        
    }
}
