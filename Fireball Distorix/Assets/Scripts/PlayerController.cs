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
    public  int Stack;
    public int StackCounter;
    // The amount of Stacks you want to start with
    public int StackStart;

    public int StackStartLevel;

    // The SpriteRenderer and the sprites
    public SpriteRenderer sr;
    public Sprite Xessy;
    public Sprite Xes_Happy;


    // The room the player is currently in
    public int CurrentRoom = 1;

    // If the player is in a no shooting enviroment
    public bool NoShooting;

    // The number of bodies delivered
    public static int BodyCount;

    // The normal mode and if you want to change
    public bool WantToChangeEasyMode;
    public static bool EasyMode = false;

    // If the player can be damaged
    public bool CanDamaged = true;

    // If the player has the respective upgrades
    public  HashSet<string> Items = new HashSet<string>();

    /*public  bool HasDash;
    public  bool HasWaterball;
    public  bool HasDamageUp;
    public  bool HasDashUpgrade;
    public  bool HasSlowUpgrade;*/
    
    // The Dash mechanic
    // The speed that the dash 
    public float DashSpeed;
    //How long the dash is
    [SerializeField] private float Dashtime = 0;
    //The start value of the dash
    public float StartDash;
    //What direction the player is dashing
    private Vector2 DashInput;
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

    private Vector2 DashDistance;


    public float Stamina;
    public float StaminaStart = 5;
    public bool IsSloMo;
    public bool CanSlow = true;

    /*public bool CanWalk;
    public Sprite Left;
    public Sprite Right;*/

    public bool CanRestart;

    // Store the scene that should trigger start
    private Scene scene;

    public static bool EasierMode;






    private void Awake()
    {
        // It is save to remove listeners even if they
        // didn't exist so far.
        // This makes sure it is added only once
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Add the listener to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(gameObject);

        // Store the creating scene as the scene to trigger start
        scene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        // Always clean up your listeners when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Listener for sceneLoaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // return if not the start calling scene
        if (string.Equals(scene.path, this.scene.path)) return;

        //Debug.Log("Re-Initializing", this);
        // do your "Start" stuff here
        StackStartLevel = Stack;
        Stamina = StaminaStart;
        if (WantToChangeEasyMode)
            EasyMode = true;
        Dashtime = StartDash;
        if (transform.GetChild(0).GetChild(0).GetComponent<Shooter>().CanShoot)
            transform.GetChild(0).GetChild(0).GetComponent<Shooter>().co = StartCoroutine(transform.GetChild(0).GetChild(0).GetComponent<Shooter>().Shoot());
        Destroy(GameObject.Find("Fireball(Clone)"));
    }









    // Start is called before the first frame update
    void Start()
    {
        

        if (EasyMode)
        {
            DashDelay /= 1.5f;
        }





        // The rb variable is set to the Rigidbody2D component of the GameObject that this script is attached to
        rb = GetComponent<Rigidbody2D>();
        

        sr = GetComponent<SpriteRenderer>();



        

        


       

        
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
                DontDestroyOnLoad(this);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                transform.position = new Vector2(0, 0);

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

        

        //if (Chest.HasUpgrade && Speed < 700)
        {
            //Upgrade();
        }




        if (StackCounter >= 5)
        {
            if (EasyMode && !EasierMode)
            {
                Stack += 2;
            }

            else if (EasyMode && EasierMode)
            {
                Stack += 4;
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

        if (Input.GetKeyDown(KeyCode.Space) && CanDash == true && IsDashing == false)
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

        if (NoShooting)
            transform.GetChild(0).GetChild(0).GetComponent<Shooter>().ShootSpecial = true;
        else
            transform.GetChild(0).GetChild(0).GetComponent<Shooter>().ShootSpecial = false;


        //print(DashSpeed);

        //print(CurrentRoom);

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

        if (DashInput != Vector2.zero)
        {
            if (Dashtime <= 0)
            {
                DashInput = Vector2.zero;
                DashDistance = Vector2.zero;
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
                if (DashInput.x == 1)
                {
                    DashDistance = new Vector2(DashSpeed * Time.deltaTime,DashDistance.y);
                    IsDashing = true;

                }
                else if (DashInput.x == -1)
                {
                    DashDistance = new Vector2(-DashSpeed * Time.deltaTime, DashDistance.y);
                    IsDashing = true;
                }
                if (DashInput.y == 1)
                {
                    DashDistance = new Vector2(DashDistance.x, DashSpeed * Time.deltaTime);
                    IsDashing = true;
                }
                else if (DashInput.y == -1)
                {
                    DashDistance = new Vector2(DashDistance.x, -DashSpeed * Time.deltaTime);
                    IsDashing = true;
                }

                if (DashInput.x != 0 && DashInput.y != 0)
                {
                    DashDistance.x /= 2;
                    DashDistance.y /= 2;
                    
                }

                rb.velocity = DashDistance;

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
        StackCounter = 0;
        sr.color = new Color(255f, 255f, 255f, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       



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

        if (DashInput == Vector2.zero)
        {
            if (Direction.x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput.x = 1;
            }
            else if (Direction.x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput.x = -1;
            }
            if (Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput.y = 1;
            }
            else if (Direction.y == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput.y = -1;
            }


            /*if (Direction.x == 1 && Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = new Vector2(1,1);

            }
            else if (Direction.x == -1 && Direction.y == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = new Vector2(-1,1);
            }
            if (Direction.y == -1 && Direction.x == 1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = new Vector2(1,-1);
            }
            else if (Direction.y == -1 && Direction.x == -1 && Input.GetKeyDown(KeyCode.Space) && CanDash)
            {
                DashInput = new Vector2(-1,-1);
            }*/

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


    public void Upgrade()
    {
        if (Items.Contains("Water Bucket"))
        {
            GetComponent<WaterBucketSpawner>().enabled = true;
        }

        if (Items.Contains("Damage Up"))
        {
            transform.GetChild(0).GetChild(0).gameObject.GetComponent<Shooter>().damage *= 1.8f;
        }

        if (Items.Contains("Dash Farther"))
        {
            DashSpeed *= 2;
        }

        if (Items.Contains("Longer Slomo Bar"))
        {
            StaminaStart *= 1.5f;
        }
    }

    /*private void WhenSceneChange()
    {



        int i = 0;
        if (i == SceneManager.sceneLoaded)
        {

        }
    }*/

}
