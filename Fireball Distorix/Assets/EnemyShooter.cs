using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private GameObject player;
    public float timer;
    public float timerStart;
    public Transform Aim;
    // A variable that says if the shooter can shoot or not
    public bool CanShoot = true;

    // The Transform of the point which spawns the fireballs
    public Transform FirePoint;

    // The fireball itself
    public GameObject FireBallPrefab;

    // The Speed of the fireball and the delay in which it can shoot
    public float FireballSpeed = 20f;
    public float FireballDelay = 5f;


    private bool temp;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = (player.transform.position - transform.position).normalized;

        // More Math shit; creates an angle from 0,0(World coords) to x,y
        // Rad2Deg converts Radians to Degrees. 180/pi
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;


        // Stores the distance between the mouse and the shooter
        float Distance = Vector2.Distance(player.transform.position, transform.position);

        // Checks if the Distance is greater or equal to one, help me... send help
        // This is because it bugs out with the angle and it's better to not move the shooter
        if (Distance >= 1 && !PauseMenu.IsPaused)
        {
            // Applies the angle as a rotation
            transform.parent.eulerAngles = new Vector3(0, 0, angle);

        }

        else
        {
            //print("test");
        }

        //print(player.GetComponent<PlayerController>().CurrentRoom + " " + transform.parent.parent.name);

        if ("Room " + player.GetComponent<PlayerController>().CurrentRoom == transform.parent.parent.parent.parent.name)
        {
            if (timer <= 0)
            {
                temp = true;
            }

            timer -= Time.deltaTime;
        }

        

      


            if (CanShoot && !PauseMenu.IsPaused && temp)
            {
                StartCoroutine(Shoot());
            }
        


        

    }



    public IEnumerator Shoot()
    {
            // Creates the fireball at the firepoint position and rotation
            GameObject Fireball = Instantiate(FireBallPrefab, FirePoint.position, FirePoint.rotation);

            // Add force to the fireball
            Rigidbody2D rb = Fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * FireballSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            // Makes it so the shooter can't shoot until the amount of seconds in FireballDelay
            CanShoot = false;
            yield return new WaitForSeconds(FireballDelay);
            CanShoot = true;
        
    }
}

