using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool BodyDelivered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.Find("Boss") == null && GameObject.Find("DashUpgrade(Clone)") == null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerController player = collision.GetComponent<PlayerController>();
        /*
        if (collision.gameObject.CompareTag("Player") && player != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        else if (collision.gameObject.CompareTag("Player") && player != null && SceneManager.GetActiveScene().buildIndex == 4 && player.sr.sprite == player.Xessy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }
        */

        if (collision.gameObject.CompareTag("People") && player == null)
        {
            BodyDelivered = true;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            if (BodyDelivered)
            {
                PlayerController.BodyCount += 1;
            }

            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (collision.gameObject.CompareTag("Player") && player != null && player.sr.sprite == player.Xessy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }
    }
}
