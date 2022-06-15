using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//THe script that does all the enemy stuff
public class Enemy : MonoBehaviour
{
    public float Health = 10;
    private SpriteRenderer sr;
    public float timer = 0.1f;
    public float Speed;
    private PlayerController Player;

    public bool isBoss;
    public int BossDamage = 10; 

    private bool PlayerCanDamaged = true;

    public bool CanDamaged = true;

    public bool temp;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (GetComponent<Boss>() != null)
            isBoss = true;

        if (isBoss && !PlayerController.NormMode)
        {
            float temp2 = Health;
            temp2 *= 2.5f;
            Health = temp2;
        }
        
    }

    // Update is called once per frame, makes sure the boss can be damaged once the shields are down
    void Update()
    {
       
        if (isBoss && transform.GetChild(0).gameObject.activeSelf)
        {
            CanDamaged = false;
        }

        
        else if (isBoss && !transform.GetChild(0).gameObject.activeSelf && !temp)
        {
            CanDamaged = true;
            temp = true;
            
        }

        
        
    }

    //How the enemies take damage
    public IEnumerator TakeDamage(float damage)
    {
        CanDamaged = false;
        
        sr.color = new Color(255f, 0f, 0f, 1f);
        Player.StackCounter += 1;
        yield return new WaitForSeconds(timer);
        Health -= damage;
        CanDamaged = true;
        sr.color = new Color(255f, 255f, 255f, 1f);
        

        if (Health <= 0)
        {
            Die();
        }
    }

    //How the enemy dies
    void Die()
    {
        

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = false;
        }

        for (int j = 0; j <= transform.childCount - 1; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }
    }

    //Checks if the player collided with the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        
        {
            if (player.CanDamaged && !isBoss && PlayerCanDamaged)
                StartCoroutine(PlayerTakeDamage(1));
            
        }

        
    }


    //If the enemy is a boss, then when the player collides with them they take constant damage as long as the player is in the boss's hixbox
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player != null)
            if (player.IsDashing == false && player.Iframes <= 0 && isBoss)
            {
                if (PlayerController.NormMode)
                {
                    //PlayerController.Stack -= 1;
                    if (player.CanDamaged && PlayerCanDamaged)// && timer >= time - 0.2)
                    {
                        StartCoroutine(PlayerTakeDamage(BossDamage));
                    }
                        
                }

                else if (!PlayerController.NormMode)
                {
                    player.Die();
                }

            }

        else if (player.IsDashing == false && player.Iframes <= 0 && !isBoss)
        {
                
            
                //PlayerController.Stack -= 1;
                if (player.CanDamaged && PlayerCanDamaged)// && timer >= time - 0.2)
                {
                    StartCoroutine(PlayerTakeDamage(1));
                }

            


        }


    }


    //Makes sure that the player has some invincablity before taking damage again
    public IEnumerator PlayerTakeDamage(float damage)
    {
        PlayerCanDamaged = false;
        StartCoroutine(Player.TakeDamage(damage));
        yield return new WaitForSeconds(0.5f);
        PlayerCanDamaged = true;
        

    }
}
