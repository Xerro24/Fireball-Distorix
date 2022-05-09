using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Creates a variable name rb, of type Rigidbody2D
    private Rigidbody2D rb;

    // Creates two variable named x and y

    private Vector2 Direction;

    // A number to multiply the speed of the character
    public float Speed = 1;

    // The Stack mechanic
    public static int Stack;
    public int StackCounter;
    // The amount of Stacks you want to start with
    public int StackStart;
    // If you can change the Stack 
    public bool WantToChangeStack = false;
    public int StackStartLevel;

    // The SpriteRenderer and the sprites
    public SpriteRenderer sr;
    public Sprite Xessy;
    public Sprite Xes_Happy;


    // The room the player is currently in
    public int CurrentRoom = 1;

    // If the player is in a no shooting enviroment
    private bool NoShooting;

    // The number of bodies delivered
    public static int BodyCount;

    // The normal mode and if you want to change
    public bool WantToChangeEasyMode;
    public static bool EasyMode = false;

    // If the player can be damaged
    public bool CanDamaged = true;

    // If the player has the respective upgrades
    public static HashSet<string> Items = new HashSet<string>();

    /*public static bool HasDash;
    public static bool HasWaterball;
    public static bool HasDamageUp;
    public static bool HasDashUpgrade;
    public static bool HasSlowUpgrade;*/



    public bool WantToChangeDash = false;
    
    // The Dash mechanic
    // The speed that the dash 
    public float DashSpeed;
    //How long the dash is
    private float Dashtime = 0;
    //The start value of the dash
    public float StartDash;
    //What direction the player is dashing
    private int DashInput = 0;
    private int DashInputY = 0;
    //If the player can dash
    private bool CanDash = true;
    //How quickly the player can dash
    public float DashDelay = 1f;
    //If the player is currently dashing
    public bool IsDashing = false;
    //The amount of time the player is invincibile after dashing 
    public float Iframes;
    public float IframesStart = 2f;
    //if the player is no longer invincible due to IFrames
    private bool IsIFramesDone = false;



    public float Stamina;
    public float StaminaStart = 5;
    public bool IsSloMo;
    public bool CanSlow = true;

    /*public bool CanWalk;
    public Sprite Left;
    public Sprite Right;*/

    public bool CanRestart;

    




    // Start is called before the first frame update
    void Start()
    {


        if (Items.Contains("Waterball"))
        {
            GetComponent<WaterBucketSpawner>().enabled = true;
        }

        if (Items.Contains("Damage"))
        {
            transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().damage *= 1.8f;
        }

        Stamina = StaminaStart;

        if (EasyMode)
        {
            DashDelay /= 1.5f;
        }

        if (Items.Contains("DashSpeed"))
        {
            DashSpeed *= 2;
        }

        if (Items.Contains("Slomo"))
        {
            StaminaStart *= 1.5f;
        }

        



        // The rb variable is set to the Rigidbody2D component of the GameObject that this script is attached to
        rb = GetComponent<Rigidbody2D>();
        if (WantToChangeEasyMode)
            EasyMode = true;

        sr = GetComponent<SpriteRenderer>();



        if (WantToChangeStack)
            Stack = StackStart;

        if (WantToChangeDash)
            Items.Add("Dash");

        StackStartLevel = Stack;


        Dashtime = StartDash;

       

    }






    // Update is called once per frame
    void Update()
    {
        // When WASD or the arrow keys are press the x and y are set to 1, -1 or 0
        // (A or left) x = -1, (D or right) x = 1, (S or down) y = -1, (W or up) y = 1

        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.X))
        {
            sr.sprite = Xessy;
        }

        if (Input.GetKeyDown(KeyCode.R) && !PauseMenu.IsPaused && CanRestart)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Stack += StackStart;
            }

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
            }

        }


        if (Input.GetKeyDown(KeyCode.I) && !PauseMenu.IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

        }

        /*if ((x != 0 || y != 0) && CanWalk)
        {
            print("is dec and can w");
            StartCoroutine(Walk());
            print("after w");

        }

        else if ((x == 0 && y == 0))
        {
            sr.sprite = Xessy;
        }*/

        if (GameObject.Find("Enemy") == null && GameObject.Find("Enemy (1)") == null && GameObject.Find("Enemy (2)") == null &&
            GameObject.Find("Enemy (3)") == null && GameObject.Find("Boss") == null && sr.sprite == Xessy)
        {
            //sr.sprite = Xes_Happy;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //if (Chest.HasUpgrade && Speed < 700)
        {
            //Upgrade();
        }




        if (StackCounter >= 5)
        {
            if (EasyMode)
            {
                Stack += 2;
            }

            else
            {
                Stack += 1;
            }

            StackCounter -= 5;

        }

        if (Iframes <= 0 && !IsIFramesDone)
        {
            sr.color = new Color(255f, 255f, 255f, 1f);
            IsIFramesDone = true;
            CanDamaged = true;
        }
        if (Iframes <= 0 && IsIFramesDone)
        {
            CanDamaged = true;
        }
        else
        {
            Iframes -= Time.deltaTime;
            CanDamaged = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanDash == true && IsDashing == false && Items.Contains("Dash"))
        {
            StartCoroutine(DashInputDelay());
        }

        if (Input.GetMouseButton(1) && Stamina > 0 && CanSlow && !PauseMenu.IsPaused)
        {
            Time.timeScale = 0.5f;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Stamina -= Time.unscaledDeltaTime;
            IsSloMo = true;

        }

        else if ((!Input.GetMouseButton(1) || Stamina <= 0) && Time.timeScale == 0.5 && !PauseMenu.IsPaused)
        {
            Time.timeScale = 1;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;
            IsSloMo = false;
        }

        if (Stamina < StaminaStart && !IsSloMo && !PauseMenu.IsPaused)
        {
            if (!Items.Contains("SlomoUpgrade"))
                Stamina += Time.unscaledDeltaTime;
            else
                Stamina += Time.unscaledDeltaTime*2;

        }

        if (Stamina >= StaminaStart && !IsSloMo && !PauseMenu.IsPaused)
        {
            Stamina = StaminaStart;
            CanSlow = true;

        }

        if (Stamina < 0)
        {
            Stamina = 0;
            CanSlow = false;
        }

        //print(DashSpeed);

        print(CurrentRoom);

        //print(EasyMode);

        //print(IsSloMo);
        //print(HasDamageUp);

         

    }

    // Less frequent Update used for physics calculations
    private void FixedUpdate()
    {
        // Creates a 2d vector. x/y = direction, speed = speed, and Time.deltatime for consistency through the frames
        // Then applies the vector to the RigidBody's velocity
        rb.velocity = new Vector2(Direction.x * Speed * Time.deltaTime, Direction.y * Speed * Time.deltaTime);

        if (DashInput != 0 || DashInputY != 0)
        {
            if (Dashtime <= 0)
            {
                DashInput = 0;
                DashInputY = 0;
                Dashtime = StartDash;
                rb.velocity = Vector2.zero;
                CanDash = false;
                Iframes = IframesStart;
                IsIFramesDone = false;
                sr.color = new Color(0f, 0f, 255f, 1f);
                IsDashing = false;
            }
            else
            {
                Dashtime -= Time.deltaTime;
                if (DashInput == 1)
                {
                    rb.velocity = Vector2.right * DashSpeed * Time.deltaTime;
                    IsDashing = true;

                }
                else if (DashInput == -1)
                {
                    rb.velocity = Vector2.left * DashSpeed * Time.deltaTime;
                    IsDashing = true;
                }
                if (DashInputY == 1)
                {
                    rb.velocity = Vector2.up * DashSpeed * Time.deltaTime;
                    IsDashing = true;
                }
                else if (DashInputY == -1)
                {
                    rb.velocity = Vector2.down * DashSpeed * Time.deltaTime;
                    IsDashing = true;
                }





                if (DashInput == 2)
                {
                    rb.velocity = new Vector2(1, 1) * DashSpeed / 2 * Time.deltaTime;
                    IsDashing = true;

                }
                else if (DashInput == -2)
                {
                    rb.velocity = new Vector2(-1, 1) * DashSpeed / 2 * Time.deltaTime;
                    IsDashing = true;
                }
                if (DashInputY == 2)
                {
                    rb.velocity = new Vector2(1, -1) * DashSpeed / 2 * Time.deltaTime;
                    IsDashing = true;
                }
                else if (DashInputY == -2)
                {
                    rb.velocity = new Vector2(-1, -1) * DashSpeed / 2 * Time.deltaTime;
                    IsDashing = true;
                }

            }
        }





    }


    public IEnumerator TakeDamage(float damage)
    {
        if (!IsDashing)
        {


            sr.color = new Color(255f, 0f, 0f, 1f);

            CanDamaged = false;

            yield return new WaitForSeconds(0.1f);

            sr.color = new Color(255f, 255f, 255f, 1f);

            Stack -= (int)damage;


            if (Stack < 0)
            {

                Die();
            }

            CanDamaged = true;
        }

    }

    public void Die()
    {
        Stack = StackStartLevel;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i <= GameObject.Find("Rooms").transform.childCount - 1; i++)
        {
            if (GameObject.Find("Rooms").transform.GetChild(i).GetChild(0).gameObject.activeInHierarchy)
                CurrentRoom = i + 1;


        }



        /*
        if (collision.gameObject.CompareTag("Rooms") && collision.name == "Room 1")
        {
            CurrentRoom = 1;
        }

        else if (collision.gameObject.CompareTag("Rooms") && collision.name == "Room 2")
        {
            CurrentRoom = 2;
        }

        else if (collision.gameObject.CompareTag("Rooms") && collision.name == "Room 3")
        {
            CurrentRoom = 3;
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

   /* public void Upgrade()
    {
        Speed = 700;
    }*/

    private IEnumerator DashInputDelay()
    {

        if (DashInput == 0)
        {
            if (Direction.x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = 1;
            }
            else if (Direction.x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = -1;
            }
            if (Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = 1;
            }
            else if (Direction.y == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = -1;
            }


            if (Direction.x == 1 && Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = 2;
            }
            else if (Direction.x == -1 && Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = -2;
            }
            if (Direction.y == -1 && Direction.x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = 2;
            }
            else if (Direction.y == -1 && Direction.x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = -2;
            }

        }
        yield return new WaitForSeconds(DashDelay);
        CanDash = true;
    }

/*
     public IEnumerator Walk()
    {
        CanWalk = false;
        if (sr.sprite == Left)
        {
            sr.sprite = Right;
            print("r");
        }
            
        else
        {
            sr.sprite = Left;
            print("l");

        }

        yield return new WaitForSeconds(0.1f);
        print("d");
        
        CanWalk = true;
    }*/


}
