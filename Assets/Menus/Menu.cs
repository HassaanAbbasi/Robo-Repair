using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button playButton;
    public string targetScene = "EyhoGym1";
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame()
    {
        SceneManager.LoadScene(targetScene);
    }
}
