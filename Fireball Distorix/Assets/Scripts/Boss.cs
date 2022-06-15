using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//THe script for the boss attack patterns
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


    // Start is called before the first frame update, on normal mode the boss dashes half as far
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        

        if (PlayerController.NormMode)
        {
            DashSpeed /= 2;
        }
    }

    // Update is called once per frame, the boss boss movement, dashing and 
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



            }

            else if (timer >= time - 0.5 && timer <= time && BossLevel > 2)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);


            }
            else if (timer >= time && timer <= time + 0.25 && BossLevel == 2)
            {

                rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));


            }

            else if (timer >= time && timer <= time + 0.5 && BossLevel > 2)
            {


                StartDash = false;
                rb.velocity = new Vector2(xy.x * DashSpeed, (xy.y * DashSpeed));


            }

            else if (timer >= time + 0.25)
            {
                StartDash = true;
                rb.velocity = new Vector2(0, 0);
                timer = 0;


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

    }

        





    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
        if (player.IsDashing == false && player.Iframes <= 0)
        {
                /*
            if (PlayerController.NormMode)
            {
                //PlayerController.Stack -= 1;
                while (player.CanDamaged)
                {
                    StartCoroutine(player.TakeDamage(100));

                }
            }
                */
            if (!PlayerController.NormMode)
            {
                player.Die();

            }



        }
    }

    ///*
    
    //*/
}
