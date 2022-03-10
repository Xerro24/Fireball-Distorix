using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCounting : MonoBehaviour
{
    public int TotalEnemies = 0;
    public int NullEnemies = 0;
    public int FinalRoom;
    public int EnemiesLeft = 0;

    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        { 
        for (int i = 1; i <= GameObject.Find("Rooms").transform.childCount; i++)
        {
            if (GameObject.Find("Room " + i))
            {

                Transform RoomEnemies = GameObject.Find("Room " + i).transform.Find("Enemies");
                for (int j = 0; j <= RoomEnemies.childCount - 1; j++)
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

                if (GameObject.Find("Room " + i).GetComponent<Rooms>().IsFinalRoom)
                {
                    FinalRoom = i;
                }

            }
        }
            
        }
        EnemiesLeft = TotalEnemies - NullEnemies;
        if (NullEnemies == TotalEnemies)
        {
            stop = true;
        }
        else
        {
            TotalEnemies = 0;
            NullEnemies = 0;
        }
        
        
    }
}
