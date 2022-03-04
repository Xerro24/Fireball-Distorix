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
    public int StackStart;
    public bool WantToChangeStack = false;
    private int StackStartLevel;

    public SpriteRenderer sr;

    public Sprite Xessy;
    public Sprite Xes_Happy;

    private bool IsPaused = false;

    public int CurrentRoom = 1;



    // Start is called before the first frame update
    void Start()
    {
        // The rb variable is set to the Rigidbody2D component of the GameObject that this script is attached to
        rb = GetComponent<Rigidbody2D>();


        sr = GetComponent<SpriteRenderer>();

        if (WantToChangeStack)
            Stack = StackStart;

        StackStartLevel = Stack;

        
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Stack = StackStartLevel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Stack += StackStart;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.C) && !IsPaused)
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = false;
        }

        if (GameObject.Find("Enemy") == null && GameObject.Find("Enemy (1)") == null && GameObject.Find("Enemy (2)") == null && 
            GameObject.Find("Enemy (3)") == null && GameObject.Find("Boss") == null && sr.sprite == Xessy)
        {
            //sr.sprite = Xes_Happy;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Chest.HasUpgrade && Speed < 700)
        {
            Upgrade();
        }

        //print(CurrentRoom);


    }

    // Less frequent Update used for physics calculations
    private void FixedUpdate()
    {
        // Creates a 2d vector. x/y = direction, speed = speed, and Time.deltatime for consistency through the frames
        // Then applies the vector to the RigidBody's velocity
        rb.velocity = new Vector2(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime);



        if (StackCounter >= 5)
        {
            Stack += 1;
            StackCounter -= 5;
        }

    }


    public IEnumerator TakeDamage(int damage)
    {

        Stack -= damage;

        sr.color = new Color(255f, 0f, 0f, 1f);

        yield return new WaitForSeconds(0.1f);

        sr.color = new Color(255f, 255f, 255f, 1f);


        if (Stack < 0)
        {

            Die();
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


}
