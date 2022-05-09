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
    private void Start()
    {
        data = SaveSystem.Load();
        PlayerController.Stack = 0;
        PlayerController.Items.Clear();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerController.Stack += 20;

    }

    public void HardMode()
    {
        PlayerController.EasyMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void Quit()
    {
        Application.Quit();
        print("Goodbye >~<");
    }

    public void Level()
    {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
        
    }

    public void Continue()
    {

        if (data != null)
        { 
            PlayerController.Stack = data.Stack;
            PlayerController.EasyMode = data.EasyMode;

            for (int i = 0; i < data.Items.Length; i++)
            {
                PlayerController.Items.Add(data.Items[i]);
            }
            PlayerController.BodyCount = data.BodyCount;
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
