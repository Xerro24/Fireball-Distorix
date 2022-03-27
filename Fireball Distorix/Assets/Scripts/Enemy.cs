using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int Health = 10;
    private SpriteRenderer sr;
    public float timer = 0.1f;
    public float Speed;
    private PlayerController Player;

    private bool isBoss;

    private bool PlayerCanDamaged = true;

    public bool CanDamaged = true;

    private bool temp;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (GetComponent<Boss>() != null)
            isBoss = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(6, Mathf.PingPong(Time.time * Speed, 6) - 3);
        if (isBoss && transform.GetChild(0).gameObject.activeSelf)
        {
            CanDamaged = false;
        }

        
        else if (isBoss && !transform.GetChild(0).gameObject.activeSelf && !temp)
        {
            CanDamaged = true;
            temp = true;
        }

        /*
        if (isBoss && !transform.GetChild(0).gameObject.activeSelf)
        {
            print("f");
        }
        //print(isBoss && !transform.GetChild(0).gameObject.activeSelf);
        */
    }

    public IEnumerator TakeDamage(int damage)
    {
        CanDamaged = false;
        Health -= damage;
        sr.color = new Color(255f, 0f, 0f, 1f);
        //if (Player.EasyMode)
        {
            //Player.StackCounter += 2;
        }
        //else
        {
            Player.StackCounter += 1;
        }
        yield return new WaitForSeconds(timer);
        CanDamaged = true;
        sr.color = new Color(255f, 255f, 255f, 1f);
        

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //gameObject.SetActive(false);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.GetComponent<MovingEnemy>().enabled = false;
        //gameObject.GetComponent<DashingEnemy>().enabled = false;
        foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = false;
        }

        for (int j = 0; j <= transform.childCount - 1; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            if (player.CanDamaged && !isBoss && PlayerCanDamaged)
                StartCoroutine(PlayerTakeDamage(1));
            
        }

        /*
        else if (collision.gameObject.CompareTag("Player") && player != null && player.Stack > 0)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            player.Stack -= 1;
        }
        */
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
            if (player.IsDashing == false && player.Iframes <= 0 && isBoss)
            {
                if (PlayerController.EasyMode)
                {
                    //PlayerController.Stack -= 1;
                    if (player.CanDamaged && PlayerCanDamaged)// && timer >= time - 0.2)
                    {
                        StartCoroutine(PlayerTakeDamage(10));
                    }
                        
                }

                else if (!PlayerController.EasyMode)
                {
                    player.Die();
                }



            }


    }

    public IEnumerator PlayerTakeDamage(int damage)
    {
        PlayerCanDamaged = false;
        StartCoroutine(Player.TakeDamage(damage));
        yield return new WaitForSeconds(0.5f);
        PlayerCanDamaged = true;
        

    }
}
