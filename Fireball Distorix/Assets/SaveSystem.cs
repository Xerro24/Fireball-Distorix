using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    static readonly string path = Application.persistentDataPath + "/Fireball Distorix.save";
    static readonly string MainMenupath = Application.persistentDataPath + "/Main.save";

    public static void Save (PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static void SaveMainMenu(MainMenu.Character[] chara)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(MainMenupath, FileMode.Create);

        SaveData data = new SaveData(chara);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData Load ()
    {

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.Log("Save Data Error: No save in path");
            return null;
        }
    }

    public static SaveData LoadMainMenu()
    {

        if (File.Exists(MainMenupath))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.Log("Save Data Error: No save in path");
            return null;
        }
    }
}
