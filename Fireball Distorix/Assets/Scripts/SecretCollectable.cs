using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCollectable : MonoBehaviour
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

        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            player.Speed += 350;
            //PlayerController.Stack += 20;
            GameObject.Find("Fire Shooter").GetComponent<Shooter>().FireballDelay = 0f;
            Destroy(gameObject);

        }
    }
}
