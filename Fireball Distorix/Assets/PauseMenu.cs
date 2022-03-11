using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    private GameObject PauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI = transform.FindChild("PauseMenu").gameObject;
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!IsPaused)
            {
                Time.timeScale = 0;
                PauseMenu.IsPaused = true;
                PauseMenuUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.IsPaused = false;
                PauseMenuUI.SetActive(true);
            }
        }
    }
}
