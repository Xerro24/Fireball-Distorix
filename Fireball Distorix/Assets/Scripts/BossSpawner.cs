using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
{
    public GameObject player;
    private int TotalEnemies;
    private int NullEnemies;
    private bool SpawnBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 1; i <= GameObject.Find("Rooms").transform.childCount; i++)
        {
            if (GameObject.Find("Room " + i))
            {
                Transform RoomEnemies = GameObject.Find("Room " + i).transform.Find("Enemies");
                for (int j = 0; j <= RoomEnemies.childCount-1; j++)
                {
                    if (RoomEnemies.GetChild(j).gameObject.GetComponent<Enemy>().enabled == false)
                    {
                        TotalEnemies++;
                        NullEnemies++;
                    }

                    else if (RoomEnemies.GetChild(j) != null)
                    {
                        TotalEnemies++;
                        
                    }
                }
                    
            }
        }
        //print("Total enemies = " + TotalEnemies);
        //print("Null enemies = " + NullEnemies);

        if (NullEnemies == TotalEnemies)
        {
            SpawnBoss = true;
        }

        else
        {
            TotalEnemies = 0;
            NullEnemies = 0;
        }
    
    

        if (SpawnBoss && player.GetComponent<PlayerController>().CurrentRoom == 12)
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
