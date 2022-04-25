using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool FollowPlayer;
    public bool RotateAround;

    public bool negative;

    public float timer;
    public float timerStart;
    private GameObject player;

    public float RotPOWER = 100;

    public bool DestroyFireball;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && FollowPlayer)
        {
            Vector2 lookDir = (player.transform.position - transform.position).normalized;

            // More Math shit; creates an angle from 0,0(World coords) to x,y
            // Rad2Deg converts Radians to Degrees. 180/pi
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;


            // Stores the distance between the mouse and the shooter
            //float Distance = Vector2.Distance(MousePos, transform.position);

            // Checks if the Distance is greater or equal to one, help me... send help
            // This is because it bugs out with the angle and it's better to not move the shooter
            if (Time.timeScale == 1)
            {
                // Applies the angle as a rotation
                transform.parent.eulerAngles = new Vector3(0, 0, angle);
                if (negative)
                {
                    transform.parent.eulerAngles = new Vector3(0, 0, angle + 180);
                }
            }

            timer = timerStart;
        }

        if (RotateAround)
        {
            transform.parent.eulerAngles = new Vector3(0, 0, timer * RotPOWER);
            if (negative)
            {
                transform.parent.eulerAngles = new Vector3(0, 0, timer * -RotPOWER);
            }
        }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fireball(Clone)" && !DestroyFireball)
        {
            Fireball fireball = collision.GetComponent<Fireball>();
            int tremp = Random.Range(1, 4);
            string hemp = "";
            if (tremp == 1)
            {
                hemp = "Bottom";
            }

            else if (tremp == 2)
            {
                hemp = "Top";
            }

            else if (tremp == 3)
            {
                hemp = "Right";
            }

            else if (tremp == 4)
            {
                hemp = "Left";
            }

            if (transform.parent.parent.gameObject.GetComponent<Boss>() == null)
            {
                //print("t");
                transform.parent.parent.parent.parent.Find(hemp).GetComponent<EdgeTeleporter>().Teleport(fireball);
            }
                

            else
                transform.parent.parent.parent.Find(hemp).GetComponent<EdgeTeleporter>().Teleport(fireball);



        }

        /*
        if (collision.name == "Fireball(Clone)" && DestroyFireball)
        {
            Fireball fireball = collision.GetComponent<Fireball>();
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<CircleCollider2D>().enabled = false;
            fireball.damage = 0;



        }
        */
    }
}
