using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        TogglePauseGame();
        }
    }

    private void TogglePauseGame()
    {
        if (pauseScreen.activeInHierarchy)
        {
        PauseGame(false);
        }
        else
        {
        PauseGame(true);
        }
    }

    private void PauseGame(bool pause)
    {
        if (pause)
        {

        Time.timeScale = 0f; 
        pauseScreen.SetActive(true);
        }
        else
        {
        Time.timeScale = 1f; 
        pauseScreen.SetActive(false); // Duraklatma ekranını gizle
        }
    }
}
