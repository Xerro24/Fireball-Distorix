using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Stack = 0;
    }
    public void NoramlMode()
    {
        PlayerController.EasyMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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

}
