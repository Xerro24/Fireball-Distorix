using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StackCounter : MonoBehaviour
{

    
    private TextMeshProUGUI text;
    private PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = player.Stack.ToString();
        if (player.Stack < 0)
        {
            text.SetText("0");
        }
        else
        {
            text.SetText(player.Stack.ToString());
        }
        
    }
}
