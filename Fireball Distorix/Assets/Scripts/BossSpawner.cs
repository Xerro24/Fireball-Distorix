using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy") == null && GameObject.Find("Enemy (1)") == null && GameObject.Find("Enemy (2)") == null && GameObject.Find("Enemy (3)") == null 
            && GameObject.Find("Enemy (4)") == null && GameObject.Find("Enemy (5)") == null 
            && GameObject.Find("Enemy (6)") == null && GameObject.Find("Enemy (7)") == null 
            && GameObject.Find("Enemy (8)") == null && GameObject.Find("Enemy (9)") == null 
            && GameObject.Find("Enemy (10)") == null && GameObject.Find("Enemy (11)") == null
            && ((player.transform.position.x >= 28 && SceneManager.GetActiveScene().buildIndex == 0) || (player.GetComponent<PlayerController>().CurrentRoom == 7 && SceneManager.GetActiveScene().buildIndex == 1)
            || (player.GetComponent<PlayerController>().CurrentRoom == 42 && SceneManager.GetActiveScene().buildIndex == 3) || SceneManager.GetActiveScene().buildIndex == 4))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Enemy>().enabled = true;
            gameObject.GetComponent<Boss>().enabled = true;

        }
    }
}
