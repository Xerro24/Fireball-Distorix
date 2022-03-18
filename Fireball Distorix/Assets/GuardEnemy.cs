using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEnemy : MonoBehaviour
{
    public GameObject[] EnemiesToKill;
    private int EnemiesKilled;

    private bool first;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        //print(EnemiesKilled);

       if (EnemiesKilled == 4 && !first)
        {
            //gameObject.SetActive(false);

            first = true;
            transform.Translate(new Vector2(18, 0), transform);


        }
       

        EnemiesKilled = 0;
    }
}
