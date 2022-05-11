using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    private GameObject PauseMenuUI;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI = transform.Find("PauseMenu").gameObject;
        PauseMenuUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        if (player.IsSloMo)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
        IsPaused = false;
        PauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
        PauseMenuUI.SetActive(true);
    }

    public void Map()
    {

    }

    public void HowToPlay()
    {
        //print("Yes");
    }

    public void MainMenu()
    {

        Time.timeScale = 1;
        IsPaused = false;
        SaveSystem.Save(player);
        Destroy(player.gameObject);
        SceneManager.LoadScene(0);
    }
}
