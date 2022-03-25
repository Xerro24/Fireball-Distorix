using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShutoff : MonoBehaviour
{
    public GameObject[] EnemiesToKill;
    private int EnemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesToKill = GameObject.FindGameObjectsWithTag("Shield Shutoff");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < EnemiesToKill.Length; i++)
        {
            //print(EnemiesToKill[i].name);
            if (EnemiesToKill[i].GetComponent<Enemy>().isActiveAndEnabled == false)
            {
                EnemiesKilled++;
                //print("joisd");
            }

        }

        if (EnemiesKilled == EnemiesToKill.Length)
        {
            //print(transform.GetChild(0).name);
            transform.GetChild(0).gameObject.SetActive(false);
            //Destroy(this);
        }

        EnemiesKilled = 0;
    }
}
