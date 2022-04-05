using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData 
{
    public int Stack;
    public bool EasyMode;
    public bool HasDash;
    public bool HasWaterball;
    public int Level;

    public SaveData (PlayerController player)
    {
        Stack = player.StackStartLevel;
        //Stack = PlayerController.Stack;
        EasyMode = PlayerController.EasyMode;
        HasDash = PlayerController.HasDash;
        HasWaterball = PlayerController.HasWaterball;
        Level = SceneManager.GetActiveScene().buildIndex;

    }

}
