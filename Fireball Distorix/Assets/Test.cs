using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    private TextMeshProUGUI text;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(10000, 0);
    }
}
