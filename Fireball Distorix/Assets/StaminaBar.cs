using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerController player;
    public Slider slider;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(1) || player.Stamina < 5)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);

            slider.value = player.Stamina;
            if (!player.CanSlow)
            {
                transform.GetChild(0).GetComponent<Image>().color = color;
            }
            else
            {
                transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255);
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        
    }
}
