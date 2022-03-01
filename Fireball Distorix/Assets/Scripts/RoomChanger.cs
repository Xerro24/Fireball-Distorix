using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{

    public GameObject Cam;
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Cam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Cam.SetActive(false);
        }
    }
}
