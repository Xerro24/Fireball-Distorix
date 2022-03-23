using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketSpawner : MonoBehaviour
{
    // Timer decreases, so we set a start
    private float timer;
    public float timerStart = 5f;

    // The water bucket
    public GameObject BucketPrefab;

    // The boundries of which the bucket spawns
    public float xRangeMin = -7f;
    public float xRangeMax = 7f;
    public float yRangeMin = -4f;
    public float yRangeMax = 4f;

    private PlayerController player;

    private GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();

        // The initial setting of the timer
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.CurrentRoom == 1)
        {
            room = GameObject.Find("Room " + player.CurrentRoom);
            if (room.GetComponent<Rooms>().IsShootingRoom)
            {
                xRangeMin = room.transform.GetChild(1).GetChild(0).position.x + 2;
                xRangeMax = room.transform.GetChild(4).GetChild(0).position.x - 2;
                yRangeMin = room.transform.GetChild(2).GetChild(0).position.y + 2;
                yRangeMax = room.transform.GetChild(3).GetChild(0).position.y - 2;
            }
            
        }


        // Checks if a water bucket has already been spawned and if the shooter isn't in water shooting mode
        if (GameObject.Find("Water Bucket(Clone)") == null && !GameObject.Find("Fire Shooter").GetComponent<Shooter>().IsWater )//&& PlayerController.Stack >= 2)
        {
            // Decreases the timer
            timer -= Time.deltaTime;
        }

        // When the time is up
        if (timer <= 0)
        {
            // Picks a random spot from the range and spawns the bucket
            float x = Random.Range(xRangeMin, xRangeMax);
            float y = Random.Range(yRangeMin, yRangeMax);
            Instantiate(BucketPrefab, new Vector2(x, y), transform.rotation);

            // Resets the timer
            timer = timerStart;
        }
    }
}
