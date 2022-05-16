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
        Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void HardMode()
    {
        PlayerController.EasyMode = false;
        Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void Quit()
    {
        Application.Quit();
        print("Goodbye >~<");
    }

    public void Level()
    {
        Load();
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

            Load();
            PlayerController.BodyCount = data.BodyCount;
            player.Upgrade();
            SceneManager.LoadScene(data.Level);
        }

    }

    public void Tutorial()
    {
        PlayerController.EasyMode = true;
        Load();
        SceneManager.LoadScene(14);
    }


    public void Load()
    {
        player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;
        PlayerController.BodyCount = 0;
        player.CanRestart = true;
        
    }
}
