using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayText : MonoBehaviour
{
    private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.SetText("Controls \nWASD - Movement \nLeft Click - Shoot \nSpace - Dash(when unlocked) \nEsc / C - Pause\nRight Click - Slow Down Time \n\n\nMechanics \nThe goal of the game is to kill all the enemies with your fireballs, but once your fireballs reaches the edge, they teleport from the edges and no longer damage enemies causing you to dodge your own fireballs. Whenever your fireball hits an enemy, a meter fills up. Once you hit 5 enemies you gain stacks. Every time you get hit you lose a stack. If you get hit with 0 stacks, you die. At the end of a level you can exchange stacks for upgrade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
