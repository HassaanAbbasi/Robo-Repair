using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool b_isPaused = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private Button m_resumeButton;
    [SerializeField]
    private Button m_helpButton;
    [SerializeField]
    private Button m_menuButton;
    [SerializeField]
    private Button m_exitButton;
    private static AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(m_resumeButton);
        Debug.Log(m_helpButton);
        Debug.Log(m_menuButton);
        Debug.Log(m_exitButton);
        m_resumeButton.onClick.AddListener(Resume);
        m_helpButton.onClick.AddListener(Help);
        m_menuButton.onClick.AddListener(MainMenu);
        m_exitButton.onClick.AddListener(Exit);
        aSource = GetComponentInChildren<AudioSource>();
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

    public static void PlaySound (AudioClip sound)
    {
        aSource.PlayOneShot(sound);
    }
}
