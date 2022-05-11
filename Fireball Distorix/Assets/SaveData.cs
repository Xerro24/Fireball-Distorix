using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData 
{
    public int SaveDataType;
    public int Stack;
    public bool EasyMode;
    public string[] Items;
    public int BodyCount;
    public int Level;

    public SaveData (PlayerController player)
    {
        SaveDataType = 1;
        Stack = player.StackStartLevel;
        EasyMode = PlayerController.EasyMode;
        Items = new string[player.Items.Count];
        player.Items.CopyTo(Items);
        BodyCount = PlayerController.BodyCount;
        Level = SceneManager.GetActiveScene().buildIndex;

    }

}
