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


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(6, Mathf.PingPong(Time.time * Speed, 6) - 3);
    }

    public IEnumerator TakeDamage(int damage)
    {
        Health -= damage;
        sr.color = new Color(255f, 0f, 0f, 1f);
        yield return new WaitForSeconds(timer);
        sr.color = new Color(255f, 255f, 255f, 1f);

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //gameObject.SetActive(false);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Enemy>().enabled = false;
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.GetComponent<MovingEnemy>().enabled = false;
        //gameObject.GetComponent<DashingEnemy>().enabled = false;
        foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            
            StartCoroutine(player.TakeDamage(1));
            
        }

        /*
        else if (collision.gameObject.CompareTag("Player") && player != null && player.Stack > 0)
        //if (player.IsDashing == false && player.Iframes <= 0)
        {
            player.Stack -= 1;
        }
        */
    }
}
