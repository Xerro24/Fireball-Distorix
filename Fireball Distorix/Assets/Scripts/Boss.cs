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

    private float otherTimer;

    public float time;

    public float DashSpeed = 5;

    private bool StartDash;

    public int BossLevel = 1;

    private bool Multidash;
    
    Vector2 xy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        

        if (PlayerController.EasyMode)
        {
            DashSpeed /= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (otherTimer >= 0)
        {
            rb.velocity = new Vector2((player.transform.position.x - transform.position.x) * speed,
                                   (player.transform.position.y - transform.position.y) * speed);

        }



        if (BossLevel >= 2)
        {
            if (StartDash)
            {
                xy = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            }


            if (timer >= time - 0.5 && timer <= time && BossLevel == 2)
            {
                StartDash = false;
                rb.velocity = new Vector2(0, 0);
                //print("Before Dash");


            }

            else if (timer >= time - 0.5 && timer <= time && BossLevel > 2)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);
                //print("Before Dash");


            }
            else if (timer >= time && timer <= time + 0.25 && BossLevel == 2)
            {

                rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));
                //print("During Dash");

            }

            //else if (timer >= time && timer <= time + 0.25 && BossLevel > 2)
            //{
                //StartDash = true;
                //xy = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;

                //rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));
                //print("During Dash");

            //}

            else if (timer >= time && timer <= time + 0.5 && BossLevel > 2)
            {
                //StartDash = true;
                //xy = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;

                StartDash = false;
                rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));
                //print("During Dash");

            }

            /*
            else if (timer >= time + 0.25 && BossLevel <= 3 && Multidash < 2)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);
                timer = time - 1f;
                Multidash++;
                //print("After Dash");

            }
            */

            else if (timer >= time + 0.25)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);
                timer = 0;
                //print("After Dash");

            }

        }
            
        timer += Time.deltaTime;
        otherTimer += Time.deltaTime;

        if (BossLevel == 1)
        {
            if (timer >= time)
            {
                timer = 0;
            }
        }

        if (BossLevel == 5 && !Multidash)
        {
            timer = -2;
            Multidash = true;
        }

        if ("Room " + player.GetComponent<PlayerController>().CurrentRoom != transform.parent.name && !GetComponent<BossSpawner>().IsChasing)
        {
            rb.velocity = new Vector2((transform.parent.transform.position.x - transform.position.x) * speed,
                                   (transform.parent.transform.position.y - transform.position.y) * speed);
            timer = -1;
            otherTimer = -1f;
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
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
        if (player.IsDashing == false && player.Iframes <= 0)
        {
                /*
            if (PlayerController.EasyMode)
            {
                //PlayerController.Stack -= 1;
                while (player.CanDamaged)
                {
                    StartCoroutine(player.TakeDamage(100));

                }
            }
                */
            if (!PlayerController.EasyMode)
            {
                player.Die();

            }



        }
    }

    ///*
    
    //*/
}
