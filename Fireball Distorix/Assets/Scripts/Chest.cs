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
            if (PlayerController.Stack >= EasyCost && PlayerController.EasyMode)
            {
                PlayerController.Stack -= EasyCost;
                if (upgrade == "Waterball")
                    PlayerController.HasWaterball = true;
                if (upgrade == "Damage")
                    PlayerController.HasDamageUp = true;
                if (upgrade == "DashUpgrade")
                {
                    PlayerController.HasDashUpgrade = true;
                    player.DashSpeed *= 2;
                }
                if (upgrade == "SlomoUpgrade")
                {
                    PlayerController.HasSlowUpgrade = true;
                    PlayerController.StaminaStart *= 1.5f;
                }


                    


                Destroy(gameObject);
            }

            else if (PlayerController.Stack >= HardCost && !PlayerController.EasyMode)
            {
                PlayerController.Stack -= HardCost;
                if (upgrade == "Waterball")
                    PlayerController.HasWaterball = true;
                if (upgrade == "Damage")
                    PlayerController.HasDamageUp = true;
                if (upgrade == "DashUpgrade")
                {
                    PlayerController.HasDashUpgrade = true;
                    player.DashSpeed *= 2;
                }
                if (upgrade == "SlomoUpgrade")
                {
                    PlayerController.HasSlowUpgrade = true;
                    PlayerController.StaminaStart *= 1.5f;
                }
                Destroy(gameObject);
            }
        }
    }
}
