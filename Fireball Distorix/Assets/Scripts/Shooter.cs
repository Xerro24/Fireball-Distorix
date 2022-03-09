using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Creates a reference to the camera
    public Camera cam;

    // Creates a variable named MousePos that will be used to store the Mouse's world position
    private Vector3 MousePos;

    // The Transform of the the rotation pivot
    public Transform Aim;

    // A variable that says if the shooter can shoot or not
    public bool CanShoot = true;

    // The Transform of the point which spawns the fireballs
    public Transform FirePoint;

    // The fireball itself
    public GameObject FireBallPrefab;

    // The waterball itself
    public GameObject WaterBallPrefab;

    // The Speed of the fireball and the delay in which it can shoot
    public float FireballSpeed = 20f;
    public float FireballDelay = 5f;

    // The Speed of the waterball and the delay in which it can shoot
    public float WaterballSpeed = 20f;
    public float WaterballDelay = 5f;

    // A variable to check if the player has picked up the water bucket
    public bool IsWater = false;

    // The SpriteRenderer and the sprites
    private SpriteRenderer sr;
    public Sprite FireShooter;
    public Sprite WaterShooter;



    public Coroutine co;

    // Start is called before the first frame update
    void Start()
    { 
        // The Sprite Renderer 
        sr = GetComponent<SpriteRenderer>();
        co = StartCoroutine(Shoot());
        Destroy(GameObject.Find("Fireball(Clone)"));
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }




    // Update is called once per frame
    void Update()
    {
        // Input.mousePosition returns the mouse coordinates in pixels
        // ScreenToWorldPoint converts the pixel coordinates to world coordinates
        // Because MousePos will be used with a Vector3, it also needs to be one but we are using 2d so we just set the z to 0
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0;

        // Vector math shit; points in the direction of the mouse
        // Normalized makes the vector have a mag of 1
        Vector2 lookDir = (MousePos - transform.position).normalized;

        // More Math shit; creates an angle from 0,0(World coords) to x,y
        // Rad2Deg converts Radians to Degrees. 180/pi
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;


        // Stores the distance between the mouse and the shooter
        float Distance = Vector2.Distance(MousePos, transform.position);

        // Checks if the Distance is greater or equal to one, help me... send help
        // This is because it bugs out with the angle and it's better to not move the shooter
        if (Distance >= 1 && Time.timeScale == 1)
        {
            // Applies the angle as a rotation
            Aim.eulerAngles = new Vector3(0, 0, angle);
        }


        // Checks if the player fired and if the shooter is allowed to shoot 
        //if (Input.GetButtonDown("Fire1") && CanShoot) //&& !PaQ.IsPaused)
        //{
        // Shoots, Coroutine for delay
        // StartCoroutine(Shoot());
        //}
        if (CanShoot)
        {

        
            while (Input.GetButton("Fire1") && CanShoot && Time.timeScale == 1)
            {
                co = StartCoroutine(Shoot());
            }
        }
    }

    // Less frequent Update used for physics calculations
    private void FixedUpdate()
    {
        
    }


    // The shooting
    public IEnumerator Shoot()
    {
        // Checks if it should shoot water
        if (IsWater)
        {
            // Creates the waterball at the firepoint position and rotation
            GameObject Waterball = Instantiate(WaterBallPrefab, FirePoint.position, FirePoint.rotation);

            // Add force to the waterball
            Rigidbody2D rb = Waterball.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * WaterballSpeed, ForceMode2D.Impulse);

            // Makes it so the shooter can't shoot until the amount of seconds in WaterballDelay
            // changes the sprite back the the fire shooter and makes IsWater false again
            CanShoot = false;
            sr.sprite = FireShooter;
            IsWater = false;
            yield return new WaitForSeconds(WaterballDelay);
            CanShoot = true;

        }
        

        else
        {
            // Creates the fireball at the firepoint position and rotation
            GameObject Fireball = Instantiate(FireBallPrefab, FirePoint.position, FirePoint.rotation);

            // Add force to the fireball
            Rigidbody2D rb = Fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * FireballSpeed *Time.fixedDeltaTime, ForceMode2D.Impulse);

            // Makes it so the shooter can't shoot until the amount of seconds in FireballDelay
            CanShoot = false;
            yield return new WaitForSeconds(FireballDelay);
            CanShoot = true;
        }



    }

    // Changes the fire shooter to the water shooter
    public void Water()
    {
        // Water is true. WOW!!!
        IsWater = true;

        // Switches the sprite to the water shooter
        sr.sprite = WaterShooter;
    }


}
