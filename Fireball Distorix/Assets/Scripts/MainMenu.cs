using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Stack = 0;
        PlayerController.HasDash = false;
        PlayerController.EasyMode = true;
        PlayerController.HasWaterball = false;
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
        SaveData data = SaveSystem.Load();

        if (data != null)
        { 
            PlayerController.Stack = data.Stack;
            PlayerController.EasyMode = data.EasyMode;
            PlayerController.HasDash = data.HasDash;
            PlayerController.HasWaterball = data.HasWaterball;
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
