using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private float timer;
    public float time;
    private Rigidbody2D rb;
    public bool GoingRightOrUp = true;
    public bool IsUpAndDownEnemy = true;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpAndDownEnemy && timer <= time && GoingRightOrUp)
        {
            //rb.velocity = new Vector2(rb.position.x, rb.position.y + 0.01f * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1 * Time.deltaTime * speed);
            
        }
        else if (IsUpAndDownEnemy && timer <= time && !GoingRightOrUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime * speed);
            
        }
        else if (IsUpAndDownEnemy)
        {
            GoingRightOrUp = !GoingRightOrUp;
            timer = 0;
        }

        if (!IsUpAndDownEnemy && timer <= time && GoingRightOrUp)
        {
            //rb.velocity = new Vector2(rb.position.x, rb.position.y + 0.01f * Time.deltaTime);
            transform.position = new Vector2(transform.position.x + 1 * Time.deltaTime * speed, transform.position.y);
            
        }
        else if (!IsUpAndDownEnemy && timer <= time && !GoingRightOrUp)
        {
            transform.position = new Vector2(transform.position.x - 1 * Time.deltaTime * speed, transform.position.y);
            
        }
        else if (!IsUpAndDownEnemy)
        {
            GoingRightOrUp = !GoingRightOrUp;
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
