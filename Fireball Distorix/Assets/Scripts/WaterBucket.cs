using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucket : MonoBehaviour
{
    private int temp_room = 1;

    private void Awake()
    {
        temp_room = GameObject.Find("Player").GetComponent<PlayerController>().CurrentRoom;
    }


    private void Update()
    {
        if (temp_room != GameObject.Find("Player").GetComponent<PlayerController>().CurrentRoom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            Shooter Shooter = GameObject.Find("Fire Shooter").GetComponent<Shooter>();
            Shooter.Water();

            Destroy(gameObject);
        }
    }
}
