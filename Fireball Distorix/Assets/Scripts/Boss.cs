using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //public float speed;

    public GameObject player;

    private Rigidbody2D rb;

    public float speed = 5;

    private float timer;

    public float time;

    public float DashSpeed = 5;

    private bool StartDash;

    public int BossLevel = 1;
    
    Vector2 xy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2((player.transform.position.x - transform.position.x) * speed, (player.transform.position.y - transform.position.y)
             * speed);


        if (BossLevel == 2)
        {
            if (StartDash)
            {
                xy = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            }


            if (timer >= time - 0.5 && timer <= time)
            {
                StartDash = false;
                rb.velocity = new Vector2(0, 0);
                //print("Before Dash");


            }

            else if (timer >= time && timer <= time + 0.25)
            {

                rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));
                //print("During Dash");

            }

            else if (timer >= time + 0.25)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);
                timer = 0;
                //print("After Dash");

            }

        }
            
        timer += Time.deltaTime;

        if (BossLevel == 1)
        {
            if (timer >= time)
            {
                timer = 0;
            }
        }
        

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
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            if (PlayerController.EasyMode)
            {
                //PlayerController.Stack -= 1;
                while (player.CanDamaged && timer >= time - 0.2)
                {
                    StartCoroutine(player.TakeDamage(2));

                }
            }

            else if (!PlayerController.EasyMode)
            {
                player.Die();
            }



        }
    }

}
