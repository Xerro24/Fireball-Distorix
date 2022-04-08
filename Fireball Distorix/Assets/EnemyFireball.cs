using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float FireballSpeed = 20f;

    public int damage = 1;

    private float timer;
    public float timerStart;

    public PlayerController Player;


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

        if (timer <= -597)
        {
            Destroy(gameObject);
        }

        print(damage);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null && player.CanDamaged && !player.IsDashing)
        {
            StartCoroutine(DestroyFireballAfterPlayerDamage(player));

        }

        //tag
        if (collision.name == "Top" || collision.name == "Bottom" || collision.name == "Left" || collision.name == "Right")
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyFireballAfterPlayerDamage(PlayerController player)
    {
        //PlayerController.Stack -= damage;
        yield return StartCoroutine(player.TakeDamage(damage));
        Debug.Log(damage);
        Destroy(gameObject);
    }
}
