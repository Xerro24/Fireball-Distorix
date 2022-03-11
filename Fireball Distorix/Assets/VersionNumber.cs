using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionNumber : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.SetText("Ver. " + Application.version);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
