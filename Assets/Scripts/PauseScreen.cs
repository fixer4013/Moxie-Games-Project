using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreenObjects;
    public bool paused;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject howToPlayMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseScreenObjects.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
    }

    public void UnpauseGame()
    {
        paused = false;
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
        Time.timeScale = 1;
        pauseScreenObjects.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
