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
}

    // Update is called once per frame
    void Update()
    {
         xy = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        if (timer >= time)
        {
            rb.velocity = new Vector2(xy.x * speed, (xy.y * speed));
            timer = 0;
        }

        else if (timer >= time + 0.2)
        {
            rb.velocity = new Vector2(0, 0);
            
        }

        else
        {
            timer += Time.deltaTime;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
