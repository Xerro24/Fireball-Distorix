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
    public bool HasDamage;
    public bool HasDashUpgrade;
    public bool HasSlomoUpgrade;
    public int BodyCount;
    public int Level;

    public SaveData (PlayerController player)
    {
        Stack = player.StackStartLevel;
        //Stack = PlayerController.Stack;
        EasyMode = PlayerController.EasyMode;
        HasDash = PlayerController.HasDash;
        HasWaterball = PlayerController.HasWaterball;
        HasDamage = PlayerController.HasDamageUp;
        HasDashUpgrade = PlayerController.HasDashUpgrade;
        HasSlomoUpgrade = PlayerController.HasSlowUpgrade;
        BodyCount = PlayerController.BodyCount;
        Level = SceneManager.GetActiveScene().buildIndex;

    }

}
