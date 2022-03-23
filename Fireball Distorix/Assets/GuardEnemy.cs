using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEnemy : MonoBehaviour
{
    public GameObject[] EnemiesToKill;
    private int EnemiesKilled;

    private bool first;
    private bool second;
    private bool third;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    public int GuardNumber;

    public int max;


    // Start is called before the first frame update
    void Start()
    {
        EnemiesToKill = GameObject.FindGameObjectsWithTag("Guard " + GuardNumber);
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
            if (Right)
                transform.Translate(new Vector2(18, 0), transform);
            if (Left)
                transform.Translate(new Vector2(-18, 0), transform);
            if (Up)
                transform.Translate(new Vector2(0, 10), transform);
            if (Down)
                transform.Translate(new Vector2(0, -10), transform);


        }

        else if (EnemiesKilled == 8 && !second)
        {
            //gameObject.SetActive(false);

            second = true;
            if (Right)
                transform.Translate(new Vector2(18, 0), transform);
            if (Left)
                transform.Translate(new Vector2(-18, 0), transform);
            if (Up)
                transform.Translate(new Vector2(0, 10), transform);
            if (Down)
                transform.Translate(new Vector2(0, -10), transform);


        }

        else if (EnemiesKilled == max && !third)
        {
            //gameObject.SetActive(false);

            third = true;
            if (Right)
                transform.Translate(new Vector2(9, 0), transform);
            if (Left)
                transform.Translate(new Vector2(-9, 0), transform);
            if (Up)
                transform.Translate(new Vector2(0, 5), transform);
            if (Down)
                transform.Translate(new Vector2(0, -5), transform);


        }


        EnemiesKilled = 0;
    }
}
