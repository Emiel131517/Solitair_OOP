using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private AudioSource buttonSound;
    private bool isPaused;
    private void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        buttonSound = gameObject.GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    private void PlayButtonSound()
    {
        buttonSound.Play();
    }
    public void QuitToMainMenu()
    {
        PlayButtonSound();
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        ResumeGame();
    }
    public void ResumeGame()
    {
        PlayButtonSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
