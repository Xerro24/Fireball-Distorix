using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{

    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -7f;
    public float yMax = 10f;

    public Rigidbody2D rb;

    public float FireballSpeed = 20f;

    public int damage = 1;

    public bool IsWater;

    private int VaporizeCounter;
    private float timer;
    public float timerStart;

    private int PlayerDamage;

    public PlayerController Player;

    public int VapCap;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = timerStart;
        PlayerDamage = damage;
        Player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        Boundaries();
        timer -= Time.deltaTime;
        if (IsWater)
        {
            if (VaporizeCounter == VapCap || timer <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (timer <= -597)
        {
            Destroy(gameObject);
        }
    }

    private void Boundaries()
    {
        /*
        Vector2 temp = transform.position;
        if (player.CurrentRoom == 1)
        {

            xMin = -8f;
            xMax = 8f;
            yMin = -4f;
            yMax = 4f;
        }

        else if (player.CurrentRoom == 2)
        {
            xMin = 10f;
            xMax = 26f;
            yMin = -4f;
            yMax = 4f;
            
        }

        else if (player.CurrentRoom == 3)
        {
            xMin = 10f;
            xMax = 26f;
            yMin = -14f;
            yMax = -6f;

        }

        else if (player.CurrentRoom == 4)
        {
            xMin = 28f;
            xMax = 44f;
            yMin = -14f;
            yMax = -6f;

        }

        if (temp.x < xMin)
        {
            temp.x = xMax;
            temp.y = Random.Range(yMin, yMax);
            transform.position = temp;

            rb.velocity = (new Vector2(0, 0));
            transform.rotation = Quaternion.identity;

            transform.eulerAngles = Vector3.forward * Random.Range(150f, 30f);
            rb.AddForce(transform.up * FireballSpeed, ForceMode2D.Impulse);
            damage = 0;



        }
        else if (temp.x > xMax)
        {
            temp.x = xMin;
            temp.y = Random.Range(yMin, yMax);
            transform.position = temp;

            rb.velocity = (new Vector2(0, 0));
            transform.rotation = Quaternion.identity;

            transform.eulerAngles = Vector3.forward * Random.Range(210f, 330f);
            rb.AddForce(transform.up * FireballSpeed, ForceMode2D.Impulse);
            damage = 0;
        }
        if (temp.y < yMin)
        {
            temp.y = yMax;
            temp.x = Random.Range(xMin, xMax);
            transform.position = temp;

            rb.velocity = (new Vector2(0, 0));
            transform.rotation = Quaternion.identity;

            transform.eulerAngles = Vector3.forward * Random.Range(120f, 240f);
            rb.AddForce(transform.up * FireballSpeed, ForceMode2D.Impulse);
            damage = 0;
        }
        else if (temp.y > yMax)
        {
            temp.y = yMin;
            temp.x = Random.Range(xMin, xMax);
            transform.position = temp;

            rb.velocity = (new Vector2(0, 0));
            transform.rotation = Quaternion.identity;

            transform.eulerAngles = Vector3.forward * Random.Range(-60f, 60f);
            rb.AddForce(transform.up * FireballSpeed, ForceMode2D.Impulse);
            damage = 0;
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        Enemy enemy = collision.GetComponent<Enemy>();
        
        //Enemy2 enemy2 = collision.GetComponent<Enemy2>();


        if (collision.gameObject.CompareTag("Player") && player != null && !IsWater)
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
            StartCoroutine(enemy.TakeDamage(damage));
            //PlayerController Player = GameObject.Find("Player").GetComponent<PlayerController>();
            

            
        }



        /*
        if (collision.gameObject.CompareTag("Wall") && damage > 0)
        {
            Destroy(gameObject);
        }


        
        if (enemy2 != null && damage > 0)
        {
            StartCoroutine(enemy2.TakeDamage(damage));
        }
        */

        if (IsWater)
        {

            if (collision.name == "Fireball(Clone)")
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
        Destroy(gameObject);
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
