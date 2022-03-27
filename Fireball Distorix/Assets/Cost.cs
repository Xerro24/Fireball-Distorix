using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cost : MonoBehaviour
{

    private TextMeshProUGUI text;

    public string Easy;
    public string Hard;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (PlayerController.EasyMode)
            text.SetText(Easy);

        else
            text.SetText(Hard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
