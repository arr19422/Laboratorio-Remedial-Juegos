using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
        }
    }

    public void TogglePause()
    {

        pauseMenu.SetActive(!isPaused);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }


    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
