using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 1; i <= GameObject.Find("Rooms").transform.childCount; i++)
        {
            if (collision.gameObject.CompareTag("Rooms") && collision.name == "Room " + i)
            {
                if (!collision.GetComponent<Rooms>().IsShootingRoom)
                {

                    StopCoroutine(transform.parent.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().co);
                    transform.parent.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().CanShoot = false;

                    transform.parent.GetComponent<PlayerController>().NoShooting = true;


                }

                else if (transform.parent.GetComponent<PlayerController>().NoShooting && collision.GetComponent<Rooms>().IsShootingRoom)
                {
                    transform.parent.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().CanShoot = true;
                    transform.parent.GetComponent<PlayerController>().NoShooting = false;

                }
                transform.parent.GetComponent<PlayerController>().CurrentRoom = i;
                break;
            }
        }
    }

    
}
