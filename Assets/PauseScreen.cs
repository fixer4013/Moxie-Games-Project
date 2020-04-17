using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject pauseScreenObjects;
    public bool paused;

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
        playerCamera.SetActive(false);
        pauseScreenObjects.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        paused = false;
        Time.timeScale = 1;
        playerCamera.SetActive(true);
        pauseScreenObjects.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
