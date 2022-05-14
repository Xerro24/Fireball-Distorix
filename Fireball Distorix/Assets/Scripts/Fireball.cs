using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float FireballSpeed = 20f;

    public float damage = 1;

    public bool IsWater;

    public bool IsEdgeball;

    private int VaporizeCounter;
    private float timer;
    public float timerStart;

    public float PlayerDamage = 1;

    public PlayerController Player;

    public int VapCap;

    public Sprite edgeball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = timerStart;
        Player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (IsWater)
        {
            if (VaporizeCounter == VapCap || timer <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (IsEdgeball)
        {
            gameObject.tag = "Edgeball";
            GetComponent<SpriteRenderer>().sprite = edgeball;
        }
            

        if (timer <= -5997)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        Enemy enemy = collision.GetComponent<Enemy>();
        
        //Enemy2 enemy2 = collision.GetComponent<Enemy2>();


        if (collision.gameObject.CompareTag("Player") && player != null && !IsWater && IsEdgeball) 
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            if (player.CanDamaged && !player.IsDashing)
                StartCoroutine(DestroyFireballAfterPlayerDamage(player));

        }

        /*
        else if (collision.gameObject.CompareTag("Player") && player != null && !IsWater && player.Stack > 0)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            player.Stack -= 1;
        }
        */

        if (enemy != null && damage > 0 && enemy.CanDamaged)
        {
            //if (!enemy.isBoss)
                StartCoroutine(enemy.TakeDamage(damage));

            //else
                //StartCoroutine(enemy.TakeDamage(1));
            //PlayerController Player = GameObject.Find("Player").GetComponent<PlayerController>();



        }



        if (IsWater)
        {

            if (collision.name == "Fireball(Clone)" || collision.name ==  "Enemy Fireball Variant(Clone)")
            {
                VaporizeCounter += 1;
                collision.GetComponent<SpriteRenderer>().enabled = false;
                collision.GetComponent<CircleCollider2D>().enabled = false;
                collision.GetComponent<Fireball>().damage = 0;

            }

        }

        

    }

    public IEnumerator DestroyFireballAfterPlayerDamage(PlayerController player)
    {
        yield return StartCoroutine(player.TakeDamage(PlayerDamage));
        //disable for ememies taking damage
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        damage = 0;

        //Destroy(gameObject);
    }

    /*
    public IEnumerator FireballDamageDelay(Enemy enemy)
    {
        int tempDamage = damage;
        damage = 0;
        yield return StartCoroutine(enemy.TakeDamage(tempDamage));
        damage = 1;
        
    }
    */
}
