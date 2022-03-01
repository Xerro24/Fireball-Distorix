using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private float timer;
    public float time;
    private Rigidbody2D rb;
    private bool GoingUp = true;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= time && GoingUp)
        {
            //rb.velocity = new Vector2(rb.position.x, rb.position.y + 0.01f * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1 * Time.deltaTime * speed);
            timer += Time.deltaTime;
        }
        else if (timer <= time && !GoingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime * speed);
            timer += Time.deltaTime;
        }
        else
        {
            GoingUp = !GoingUp;
            timer = 0;
        }
    }
}
