using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fireball(Clone)")
        {
            Fireball fireball = collision.GetComponent<Fireball>();
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<CircleCollider2D>().enabled = false;
            fireball.damage = 0;
            
        }
    }
}
