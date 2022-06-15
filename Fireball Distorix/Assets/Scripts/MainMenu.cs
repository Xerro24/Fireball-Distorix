using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [Serializable]
    public class Character
    {
        public Sprite CharaSprite;
        public string CharaName;
        public string CharaDesc;
        public bool IsUnlocked;
        public string UnlockDesc;

        public Character(Sprite sprite, string name, string desc)
        {
            CharaSprite = sprite;
            CharaName = name;
            CharaDesc = desc;
        }
    }


    SaveData data;
    SaveData MainData;

    private PlayerController player;

    public Character[] StaticSucks;
    public static Character[] Chara;

    public static int CharaIndex = 0;
    

    public Transform CharaSprite;
    public Transform CharaName;
    public Transform CharaDesc;


    public Toggle DevMode;

    //public Character chara;

    //[SerializeField] public ArrayList chara = new ArrayList();



    private void Start()
    {
        Chara = StaticSucks;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        data = SaveSystem.Load();
        //MainData = SaveSystem.LoadMainMenu();
        player.Stack = 0;
        player.Items.Clear();
        PlayerController.NormMode = true;
        PlayerController.EasierMode = false;

        DevMode.isOn = PlayerController.DevMode;

        player.hasDamageUpgrade = false;

        //print(StaticSucks[1].IsUnlocked);

        /*if (MainData != null)
        {
            CharaIndex = data.CharaIndex;
            print(data.Chara);
            for (int i = 0; i < data.Chara.Length-1; i++)
            {
                print("I dsju sjhgy thgis");
                print(data.Chara[i]);
                print(Chara[i].IsUnlocked);
                data.Chara[i] = Chara[i].IsUnlocked;
            }

            
        }*/

        //SaveSystem.SaveMainMenu(Chara);


        //print(Chara[1].IsUnlocked);




        string path = Application.persistentDataPath + "/Fireball Distorix.save";
        if (File.Exists(path))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        //print(CharaIndex);
        CharaSprite.GetComponent<Image>().sprite = Chara[CharaIndex].CharaSprite;
        CharaName.GetComponent<TextMeshProUGUI>().SetText(Chara[CharaIndex].CharaName);
        CharaDesc.GetComponent<TextMeshProUGUI>().SetText(Chara[CharaIndex].CharaDesc);
        if (!Chara[CharaIndex].IsUnlocked)
        {
            CharaSprite.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
            CharaName.GetComponent<TextMeshProUGUI>().SetText("???");
            CharaDesc.GetComponent<TextMeshProUGUI>().SetText(Chara[CharaIndex].UnlockDesc);
        }
        else
        {
            CharaSprite.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);

            player.sr.sprite = Chara[CharaIndex].CharaSprite;

        }


    }
    public void NoramlMode()
    {
        PlayerController.NormMode = true;
        player.Stack += 20;
        Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void HardMode()
    {
        PlayerController.NormMode = false;
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
            PlayerController.NormMode = data.NormMode;
            PlayerController.EasierMode = data.EasierMode;

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

    public void NormMode()
    {
        PlayerController.NormMode = true;
        PlayerController.EasierMode = true;
        player.Stack += 20;
        Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void Tutorial()
    {
        PlayerController.NormMode = true;
        player.Stack += 20;
        Load();
        SceneManager.LoadScene(14);
    }


    public void Load()
    {
        player.transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot = true;
        PlayerController.BodyCount = 0;
        player.CanRestart = true;
        
    }

    public void CharacterSelectLeftButton()
    {
        //print(CharaIndex);
        if (CharaIndex == 0)
        {
            //print("o");
            CharaIndex = Chara.Length -1;
            
        }
        else
        {
            //print("e");
            CharaIndex -= 1;
        }




    }

    public void CharacterSelectRightButton()
    {
        //print(CharaIndex);
        if (CharaIndex == Chara.Length - 1)
        {
            CharaIndex = 0;
        }
        else
        {
            CharaIndex += 1;
        }


    }

    public void DevModeChanger()
    {
        
        PlayerController.DevMode = DevMode.isOn;

    }
}
