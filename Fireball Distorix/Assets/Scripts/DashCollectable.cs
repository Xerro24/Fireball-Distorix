using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollectable : MonoBehaviour
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
            player.Items.Add("Dash");
            Destroy(gameObject);
        }
    }
}
