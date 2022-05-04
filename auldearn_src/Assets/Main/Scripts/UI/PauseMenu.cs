using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused;
    public GameObject menu, muteBtn, unMuteBtn, healthCounters;

    private void Awake()
    {
        _paused = false;
        menu.SetActive(false);
        
        
        if (!Bools.muteActive)
        {
            unMuteBtn.SetActive(false);
            muteBtn.SetActive(true);
        }
        else
        {
            unMuteBtn.SetActive(true);
            muteBtn.SetActive(false);
        }
    }

    private void Update()
    {
        var b = Gamepad.all[0].bButton.isPressed;
        // if start pressed pause game else resume.
        if (Gamepad.all[0].startButton.isPressed && !_paused)
            PauseGame();
        else if (Gamepad.all[0].aButton.isPressed && _paused)
            ResumeGame();
        else if (b && _paused || b && CombatManager.gameOver)
            StartCoroutine(WhichScene("01_MainMenu"));
        if (Gamepad.all[0].xButton.isPressed && CombatManager.gameOver)
        {
            StartCoroutine(WhichScene("TestBox"));
        }

        GameVolume();
    }

    private void PauseGame()
    {
        // Pause - volume & time.
        Time.timeScale = 0f;
        _paused = true;
        menu.SetActive(true);
        healthCounters.SetActive(false);
    }

    public void ResumeGame()
    {
        // Resume - volume & time.
        Time.timeScale = 1f;
        AudioManager.MuteActive();
        _paused = false;
        menu.SetActive(false);
        healthCounters.SetActive(true);
    }

    private IEnumerator WhichScene(string scene)
    {
        Time.timeScale = 1f;
        _paused = false;
        menu.SetActive(false);
        AudioManager.FadeMusic(false, true);
        Fader.FadeScene(false, true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(scene);
    }

    private void GameVolume()
    {
        // Mute Game
        if (Gamepad.all[0].dpad.left.isPressed && _paused)
        {
            Bools.muteActive = true;
            muteBtn.SetActive(false);
            unMuteBtn.SetActive(true);
            AudioManager.MuteActive();
        }
        else if (Gamepad.all[0].dpad.right.isPressed && _paused)
        {
            Bools.muteActive = false;
            unMuteBtn.SetActive(false);
            muteBtn.SetActive(true);
            AudioManager.MuteActive();
        }
    }
}