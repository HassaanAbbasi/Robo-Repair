using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]
public class GameController : MonoBehaviour
{
    public static bool b_isPaused = false;

    private GameObject pauseMenu;

    private Button m_resumeButton;
    private Button m_helpButton;
    private Button m_menuButton;
    private Button m_exitButton;

    // Start is called before the first frame update
    void Start()
    {
        m_resumeButton.onClick.AddListener(Resume);
        m_helpButton.onClick.AddListener(Help);
        m_menuButton.onClick.AddListener(MainMenu);
        m_exitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (b_isPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        b_isPaused = true;
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
        b_isPaused = false;
        pauseMenu.SetActive(false);
    }

    void Help()
    {

    }

    void MainMenu()
    {

    }

    void Exit()
    {
        Application.Quit();
    }
}
