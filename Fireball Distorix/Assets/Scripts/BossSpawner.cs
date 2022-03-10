using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
{
    public GameObject player;
    //private int TotalEnemies;
    //private int NullEnemies;
    public bool SpawnBoss = false;
    //private int FinalRoom;

    private RoomCounting room;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
        player = GameObject.Find("Player");
        room = GameObject.Find("Rooms").GetComponent<RoomCounting>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //print("Total enemies = " + TotalEnemies);
        //print("Null enemies = " + NullEnemies);

        if (room.stop)
        {
            SpawnBoss = true;
        }

        
    
    

        if (SpawnBoss && player.GetComponent<PlayerController>().CurrentRoom == room.FinalRoom)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Enemy>().enabled = true;
            gameObject.GetComponent<Boss>().enabled = true;

        }

        if (gameObject.GetComponent<Enemy>().Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
