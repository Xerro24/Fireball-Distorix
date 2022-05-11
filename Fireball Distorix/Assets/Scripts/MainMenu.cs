using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;


public class MainMenu : MonoBehaviour
{

    SaveData data;
    private PlayerController player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        data = SaveSystem.Load();
        player.Stack = 0;
        player.Items.Clear();
        PlayerController.BodyCount = 0
            ;

        string path = Application.persistentDataPath + "/Fireball Distorix.save";
        if (File.Exists(path))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
    public void NoramlMode()
    {
        PlayerController.EasyMode = true;
        player.Stack += 20;
        player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }

    public void HardMode()
    {
        PlayerController.EasyMode = false;
        player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void Quit()
    {
        Application.Quit();
        print("Goodbye >~<");
    }

    public void Level()
    {
        player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;

        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
        
    }

    public void Continue()
    {

        if (data != null)
        { 
            player.Stack = data.Stack;
            PlayerController.EasyMode = data.EasyMode;

            for (int i = 0; i < data.Items.Length; i++)
            {
                player.Items.Add(data.Items[i]);
            }
            PlayerController.BodyCount = data.BodyCount;
            player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;
            player.Upgrade();
            SceneManager.LoadScene(data.Level);
        }

    }

    /*
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7()
    {
        SceneManager.LoadScene(7);
    }
    */
}
