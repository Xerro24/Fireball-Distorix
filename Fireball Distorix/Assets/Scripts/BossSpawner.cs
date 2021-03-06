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

    public GameObject DashPrefab;

    private RoomCounting room;

    private bool temp;

    public bool IsChasing = false;

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

        if (room.stop && !temp)
        {
            SpawnBoss = true;
            temp = true;
        }

        
    
    

        if (SpawnBoss && player.GetComponent<PlayerController>().CurrentRoom == room.FinalRoom && !GetComponent<Boss>().isActiveAndEnabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Enemy>().enabled = true;
            GetComponent<Boss>().enabled = true;
            for (int j = 0; j <= transform.childCount - 1; j++)
            {
                transform.GetChild(j).gameObject.SetActive(true);
            }

            SpawnBoss = false;
        }

        if (SpawnBoss && player.GetComponent<PlayerController>().CurrentRoom == room.FinalRoom && IsChasing)
        {
            print("s");
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Enemy>().enabled = true;
            GetComponent<Boss>().enabled = true;
            for (int j = 0; j <= transform.childCount - 1; j++)
            {
                transform.GetChild(j).gameObject.SetActive(true);
            }

            IsChasing = false;
            GetComponent<Boss>().BossLevel = 5;
            SpawnBoss = false;
        }



        if (GetComponent<Enemy>().Health <= 0)
        {
            /*if (GetComponent<Boss>().BossLevel == 2)
            {
                GameObject DashUpgrade = Instantiate(DashPrefab, transform.position, transform.rotation);
                //print("danf");
            }*/
            gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level 5" && player.GetComponent<PlayerController>().CurrentRoom == 10)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Boss>().enabled = true;
            GetComponent<Boss>().BossLevel = 1;
            IsChasing = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsChasing == true && collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().Die();
        }
    }
}
