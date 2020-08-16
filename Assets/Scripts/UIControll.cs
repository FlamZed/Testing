using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControll : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject startMenu;

    public void Pause()
    {
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);
 
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);

        PlayerController.start = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
