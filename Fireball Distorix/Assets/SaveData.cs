using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData 
{
    public int SaveDataType;
    public int Stack;
    public bool NormMode;
    public bool EasierMode;
    public string[] Items;
    public int BodyCount;
    public static bool Dead;
    public int Level;
    public int CharaIndex;
    public static bool Xessy;
    public bool[] Chara;

    public SaveData (PlayerController player)
    {
        SaveDataType = 1;
        Stack = player.StackStartLevel;
        NormMode = PlayerController.NormMode;
        EasierMode = PlayerController.EasierMode;
        Items = new string[player.Items.Count];
        player.Items.CopyTo(Items);
        
        BodyCount = PlayerController.BodyCount;
        
        Level = SceneManager.GetActiveScene().buildIndex;
        

    }

    public SaveData(MainMenu.Character[] chara)
    {

        CharaIndex = MainMenu.CharaIndex;
        for (int i = 0; i < chara.Length-1; i++)
        {
            Chara[i] = chara[i].IsUnlocked;
        }

    }

}
