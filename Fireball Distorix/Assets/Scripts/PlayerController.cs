using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Creates a variable name rb, of type Rigidbody2D
    private Rigidbody2D rb;

    // Creates two variable named x and y
    private float x;
    private float y;

    // A number to multiply the speed of the character
    public float Speed = 1;

    // The Stack mechanic
    public static int Stack;
    public int StackCounter;
    // The amount of Stacks you want to start with
    public int StackStart;
    // If you can change the Stack 
    public bool WantToChangeStack = false;
    private int StackStartLevel;

    public SpriteRenderer sr;

    public Sprite Xessy;
    public Sprite Xes_Happy;

    

    public int CurrentRoom = 1;

    private bool temp;

    public static int BodyCount;

    public bool easychanger;
    public static bool EasyMode = false;

    public bool CanDamaged = true;

    public static bool HasDash;
    public static bool HasWaterball;

    public bool WantToChangeDash = false;

    public float DashSpeed;
    private float Dashtime = 0;
    public float StartDash;
    private int DashInput = 0;
    private int DashInputY = 0;
    private bool CanDash = true;
    public float DashDelay = 1f;
    public bool IsDashing = false;

    public float Iframes;
    public float IframesStart = 2f;

    private bool IsIFramesDone = false;



    // Start is called before the first frame update
    void Start()
    {
        // The rb variable is set to the Rigidbody2D component of the GameObject that this script is attached to
        rb = GetComponent<Rigidbody2D>();
        if (easychanger)
            EasyMode = true;

        sr = GetComponent<SpriteRenderer>();

        

        if (WantToChangeStack)
            Stack = StackStart;

        if (WantToChangeDash)
            HasDash = true;

        StackStartLevel = Stack;

        if (EasyMode && SceneManager.GetActiveScene().buildIndex == 1)
            Stack += 20;

        Dashtime = StartDash;

        if (HasWaterball)
        {
            GetComponent<WaterBucketSpawner>().enabled = true;
        }


    }






    // Update is called once per frame
    void Update()
    {
        // When WASD or the arrow keys are press the x and y are set to 1, -1 or 0
        // (A or left) x = -1, (D or right) x = 1, (S or down) y = -1, (W or up) y = 1
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.X))
        {
            sr.sprite = Xessy;
        }

        if (Input.GetKeyDown(KeyCode.R) && !PauseMenu.IsPaused)
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

        if (Input.GetKeyDown(KeyCode.Space) && CanDash == true && IsDashing == false && HasDash)
        {
            StartCoroutine(DashInputDelay());
        }

       

        //print(CurrentRoom);


    }

    // Less frequent Update used for physics calculations
    private void FixedUpdate()
    {
        // Creates a 2d vector. x/y = direction, speed = speed, and Time.deltatime for consistency through the frames
        // Then applies the vector to the RigidBody's velocity
        rb.velocity = new Vector2(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime);

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
                    rb.velocity = new Vector2(1, 1) * DashSpeed/2 * Time.deltaTime;
                    IsDashing = true;

                }
                else if (DashInput == -2)
                {
                    rb.velocity = new Vector2(-1, 1) * DashSpeed/2 * Time.deltaTime;
                    IsDashing = true;
                }
                if (DashInputY == 2)
                {
                    rb.velocity = new Vector2(1,-1) * DashSpeed/2 * Time.deltaTime;
                    IsDashing = true;
                }
                else if (DashInputY == -2)
                {
                    rb.velocity = new Vector2(-1, -1) * DashSpeed/2 * Time.deltaTime;
                    IsDashing = true;
                }

            }
        }



        

    }


    public IEnumerator TakeDamage(int damage)
    {
        if (!IsDashing)
        {
            

            sr.color = new Color(255f, 0f, 0f, 1f);

            CanDamaged = false;

            yield return new WaitForSeconds(0.1f);

            sr.color = new Color(255f, 255f, 255f, 1f);

            Stack -= damage;


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
        for (int i = 1; i <= GameObject.Find("Rooms").transform.childCount; i++)
        {
            if (collision.gameObject.CompareTag("Rooms") && collision.name == "Room " + i)
            {
                if (!collision.GetComponent<Rooms>().IsShootingRoom)
                {

                    StopCoroutine(gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().co);
                    gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().CanShoot = false;
                    
                    temp = true;
                    
                }

                else if (temp && collision.GetComponent<Rooms>().IsShootingRoom)
                {
                    gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().CanShoot = true;
                    temp = false;
                    
                }
                CurrentRoom = i;
                break;
            }
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

    public void Upgrade()
    {
        Speed = 700;
    }

    private IEnumerator DashInputDelay()
    {

        if (DashInput == 0)
        {
            if (x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = 1;
            }
            else if (x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = -1;
            }
            if (y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = 1;
            }
            else if (y == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = -1;
            }


            if (x == 1 && y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = 2;
            }
            else if (x == -1 && y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = -2;
            }
            if (y == -1 && x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = 2;
            }
            else if (y == -1 && x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInputY = -2;
            }

        }
        yield return new WaitForSeconds(DashDelay);
        CanDash = true;
    }


}
