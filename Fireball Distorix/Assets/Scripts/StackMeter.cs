using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StackMeter : MonoBehaviour
{
    private Image sr;
    private PlayerController Player;

    public Sprite StackEmpty;
    public Sprite Stack1;
    public Sprite Stack2;
    public Sprite Stack3;
    public Sprite Stack4;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Image>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.StackCounter == 0)
        {
            sr.sprite = StackEmpty;
        }
        else if (Player.StackCounter == 1)
        {
            sr.sprite = Stack1;
        }
        else if (Player.StackCounter == 2)
        {
            sr.sprite = Stack2;
        }
        else if (Player.StackCounter == 3)
        {
            sr.sprite = Stack3;
        }
        else if (Player.StackCounter == 4)
        {
            sr.sprite = Stack4;
        }
        else
        {
            sr.sprite = StackEmpty;
        }
    }
}
