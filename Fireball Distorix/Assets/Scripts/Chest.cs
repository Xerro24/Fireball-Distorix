using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //public static bool HasUpgrade = false;

    public int EasyCost;
    public int HardCost;
    public string upgrade;
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
            if (player.Stack >= EasyCost && PlayerController.NormMode)
            {
                player.Stack -= EasyCost;
                AddItems(player);
               
            }

            else if (player.Stack >= HardCost && !PlayerController.NormMode)
            {
                player.Stack -= HardCost;
                AddItems(player);
            }
        }
    }

    private void AddItems(PlayerController player)
    {
        player.Items.Add(upgrade);
        if (player.Items.Contains("Water Bucket"))
        {
            player.GetComponent<WaterBucketSpawner>().enabled = true;
        }

        if (player.Items.Contains("Damage Up"))
        {
            player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().damage *= 1.8f;
        }
        if (upgrade == "Dash Farther")
        {
            player.DashSpeed *= 2; 
        }
        if (upgrade == "Longer Slomo Bar")
        {
            player.StaminaStart *= 1.5f;
        }
        Destroy(gameObject);
    }
}
