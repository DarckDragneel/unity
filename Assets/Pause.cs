using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Menupause;
    public bool isPaused;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Menupause.SetActive(true);
                isPaused = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (isPaused == true)
            {
                Resume();

            }

        }
    }
    public void Resume()

    {
        Menupause.SetActive(!isPaused);
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
