using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StackCounter : MonoBehaviour
{

    
    private TextMeshProUGUI text;

    

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = player.Stack.ToString();
        if (PlayerController.Stack < 0)
        {
            text.SetText("0");
        }
        else
        {
            text.SetText(PlayerController.Stack.ToString());
        }
        
    }
}
