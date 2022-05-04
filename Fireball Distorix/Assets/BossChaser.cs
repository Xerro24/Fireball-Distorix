using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaser : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.GetComponent<PlayerController>().CurrentRoom == room.FinalRoom)
    }
}
