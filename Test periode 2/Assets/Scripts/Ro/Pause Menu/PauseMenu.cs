using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool inPauseMenu;
    public GameObject pauseMenu, screenUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPauseMenu == true)
        {
            pauseMenu.SetActive(true);
            screenUi.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inPauseMenu = false;
            }
        }
        else
        {
            pauseMenu.SetActive(false);
            screenUi.SetActive(true);
            Time.timeScale = 1;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inPauseMenu = true;
            }
        }
    }
    public void BackToGame()
    {
        inPauseMenu = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
