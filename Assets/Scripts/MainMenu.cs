using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private bool isMuted = false;  // Flag to track whether the audio is muted
    private AudioSource audioSource;
    public GameObject respawnPoint;
    public Slider awarenessSlider;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        // Assuming you have a player GameObject that you want to teleport
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player GameObject and respawnPoint GameObject are not null
        if (player != null && respawnPoint != null)
        {
            // Teleport the player to the respawn point
            player.transform.position = respawnPoint.transform.position;

            // Optionally, reset the player's velocity or perform other necessary actions
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
            }
        }

        // Reset the time scale to unpause the game
        Time.timeScale = 1f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMute()
    {
        if (isMuted)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }

    public void Mute()
    {
        // Mute the audio
        isMuted = true;
        audioSource.mute = true;
    }

    public void Unmute()
    {
        // Unmute the audio
        isMuted = false;
        audioSource.mute = false;
    }
}
