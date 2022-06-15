using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cost : MonoBehaviour
{

    private TextMeshProUGUI text;

    public string Easy;
    public string Hard;
    public string cost;

    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<TextMeshProUGUI>();

        if (PlayerController.NormMode)
            cost = Easy;

        else
            cost = Hard;

        text.SetText(cost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
