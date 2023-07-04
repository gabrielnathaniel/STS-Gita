using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    [SerializeField] GameObject controlsMenu;
    [SerializeField] SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && controlsMenu.activeSelf == false)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        ResumeGame();
        if (sceneFader != null)
        {
            sceneFader.FadeTo("MainMenu");
        }
    }
}
