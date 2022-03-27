using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //public static bool HasUpgrade = false;

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
            if (PlayerController.Stack >= 25 && PlayerController.EasyMode)
            {
                PlayerController.Stack -= 25;
                PlayerController.HasWaterball = true;
                Destroy(gameObject);
            }

            else if (PlayerController.Stack >= 5 && !PlayerController.EasyMode)
            {
                PlayerController.Stack -= 5;
                PlayerController.HasWaterball = true;
                Destroy(gameObject);
            }
        }
    }
}
