using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static float PausedTime;

    // Receive the PauseMenu game object
    public GameObject pauseMenuUI;
    public GameObject volumePanel;

    public TMP_Text menuLabelText;

    //private ScoreSystem scoreSystem;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        Resume();
        //scoreSystem = FindObjectOfType<ScoreSystem>();
        PausedTime = 0f;
    }
    
    public void SwitchPaused()
    {
        // IF the game is already paused, exits the pause menu
        if (isGamePaused)
        {
            Resume();
        }
        // ELSE join the pause menu
        else
        {
            Pause();
        }
    }
    // Exit the Pause Menu
    public void Resume()
    {
        audioManager.PlaySFX("Button");
        // Exit the Pause Menu in the canvas
        pauseMenuUI.SetActive(false);

        // Unfreeze the game
        Time.timeScale = 1f;

        // Set false meaning that the game is NOT paused
        isGamePaused = false;
    }

    // Open the Pause Menu
    public void Pause()
    {
        audioManager.PlaySFX("Button");

        menuLabelText.text = "PAUSADO";
        // Show the Pause Menu in the canvas
        pauseMenuUI.SetActive(true);

        // Freeze the game
        Time.timeScale = 0f;
        
        // Set true meaning that the game is paused
        isGamePaused = true;
        
        //BackgroundImage.SetActive(true);
    }


    // Open the Main Menu
    public void FinishAndLoadMenu()
    {
        audioManager.PlaySFX("Button");

        // Comment this region to set offline
        
        #region Online
        
        // StartCoroutine(FinishAndLoadMenuEnumerator());
        
        #endregion Online
        
        // Uncomment this region to set offline

        #region Offline
        
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene(0);
        
        #endregion Offline
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Volume()
    {
        audioManager.PlaySFX("Button");
        menuLabelText.text = "VOLUME";
        volumePanel.SetActive(true);
    }
}
