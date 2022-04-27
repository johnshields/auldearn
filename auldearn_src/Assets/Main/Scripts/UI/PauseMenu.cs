using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused;
    public GameObject menu;

    private void Awake()
    {
        _paused = false;
        menu.SetActive(false);
    }

    private void Update()
    {
        // if start pressed pause game else resume.
        if (Gamepad.all[0].startButton.isPressed && !_paused)
            PauseGame();
        else if (Gamepad.all[0].aButton.isPressed && _paused)
            ResumeGame();
    }

    private void PauseGame()
    {
        // Pause - volume & time.
        print("Game paused...");
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        _paused = true;
        menu.SetActive(true);
    }

    public void ResumeGame()
    {
        // Resume - volume & time.
        print("Game resumed...");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        _paused = false;
        menu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
        _paused = false;
    }
}