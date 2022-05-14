using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTeleporter : MonoBehaviour
{

    private Transform Room;
    private string selfname;

    public Sprite edgeball;

    // Start is called before the first frame update
    void Start()
    {
        Room = gameObject.transform.parent;
        selfname = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fireball(Clone)" || collision.name == "Waterball(Clone)")
        {
            
            Fireball fireball = collision.GetComponent<Fireball>();
            //GameObject FireBall = collision.gameObject;

            Teleport(fireball);

            
        }
    }

    public void Teleport(Fireball fireball)
    {
        Vector2 temp;
        if (selfname == "Bottom")
        {

            //Room.GetChild(1);
            Vector2 TopLeft = Room.GetChild(1).GetChild(0).position;
            Vector2 TopRight = Room.GetChild(1).GetChild(1).position;

            //temp.x = xMax;
            //temp.y = Random.Range(yMin, yMax);
            //transform.position = temp;


            temp.x = Random.Range(TopLeft.x, TopRight.x);
            temp.y = TopLeft.y - 0.2f;
            if (fireball.IsWater)
                temp.y = TopLeft.y - 0.5f;
            Edgeball(fireball, temp);
        }

        else if (selfname == "Top")
        {
            Room.GetChild(2);
            Vector2 BottomLeft = Room.GetChild(2).GetChild(0).position;
            Vector2 BottomRight = Room.GetChild(2).GetChild(1).position;

            //temp.x = xMax;
            //temp.y = Random.Range(yMin, yMax);
            //transform.position = temp;


            temp.x = Random.Range(BottomLeft.x, BottomRight.x);
            temp.y = BottomLeft.y + 0.2f;
            if (fireball.IsWater)
                temp.y = BottomLeft.y + 0.5f;
            Edgeball(fireball, temp);
        }

        else if (selfname == "Right")
        {
            Room.GetChild(3);
            Vector2 BottomLeft = Room.GetChild(3).GetChild(0).position;
            Vector2 BottomRight = Room.GetChild(3).GetChild(1).position;

            //temp.x = xMax;
            //temp.y = Random.Range(yMin, yMax);
            //transform.position = temp;


            temp.y = Random.Range(BottomLeft.y, BottomRight.y);
            temp.x = BottomLeft.x + 0.2f;
            if (fireball.IsWater)
                temp.x = BottomLeft.x + 0.5f;
            Edgeball(fireball, temp);
        }

        else if (selfname == "Left")
        {
            Room.GetChild(4);
            Vector2 BottomLeft = Room.GetChild(4).GetChild(0).position;
            Vector2 BottomRight = Room.GetChild(4).GetChild(1).position;

            //temp.x = xMax;
            //temp.y = Random.Range(yMin, yMax);
            //transform.position = temp;


            temp.y = Random.Range(BottomLeft.y, BottomRight.y);
            temp.x = BottomLeft.x - 0.2f;
            if (fireball.IsWater)
                temp.x = BottomLeft.x - 0.5f;
            Edgeball(fireball, temp);
        }
    }

    public void Edgeball(Fireball fireball, Vector2 temp)
    {
        fireball.transform.position = temp;

        fireball.rb.velocity = (new Vector2(0, 0));
        fireball.transform.rotation = Quaternion.identity;

        fireball.transform.eulerAngles = Vector3.forward * Random.Range(120f, 240f);
        fireball.rb.AddForce(fireball.transform.up * fireball.FireballSpeed, ForceMode2D.Impulse);
        fireball.damage = 0;
        fireball.IsEdgeball = true;
        
        
    }


}
