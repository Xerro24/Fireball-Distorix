using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    private TextMeshProUGUI text;

    private RoomCounting room;

    private int EnemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        room = GameObject.Find("Rooms").GetComponent<RoomCounting>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = player.Stack.ToString();
        //EnemiesLeft = room.TotalEnemies - room.NullEnemies;
            text.SetText("Enemies: " + room.EnemiesLeft);
        

    }
}
