using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuItems, confirmPanel, controlsPanel, muteBtn, unMuteBtn;
    private bool _confirm, _controls;

    public void Awake()
    {
        AudioManager.MuteActive();
        confirmPanel.SetActive(false);
        _confirm = false;
        _controls = false;

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
        if (EnableMenu.menuActive)
        {
            if (Gamepad.all.Count <= 0) return;
            // Start Game
            if (Gamepad.all[0].aButton.isPressed && !_confirm && !_controls)
            {
                StartCoroutine(WhichScene("TestBox"));
            }
            // Controls Menu
            else if (Gamepad.all[0].xButton.isPressed && !_confirm && !_controls)
            {
                _controls = true;
            }
            // Confirm Exit.
            else if (Gamepad.all[0].bButton.isPressed && !_confirm && !_controls)
            {
                _confirm = true;
            }
            // Mute Game
            else if (Gamepad.all[0].dpad.left.isPressed && !_confirm && !_controls)
            {
                Bools.muteActive = true;
                muteBtn.SetActive(false);
                unMuteBtn.SetActive(true);
                AudioManager.MuteActive();
            }
            else if (Gamepad.all[0].dpad.right.isPressed && !_confirm && !_controls)
            {
                Bools.muteActive = false;
                unMuteBtn.SetActive(false);
                muteBtn.SetActive(true);
                AudioManager.MuteActive();
            }

            // Sub Menus
            if (_controls)
            {
                controlsPanel.SetActive(true);
                Controls();
            }
            else if (_confirm)
            {
                confirmPanel.SetActive(true);
                Confirm();
            }
        }
    }

    private void Controls()
    {
        if (Gamepad.all[0].yButton.isPressed && _controls)
        {
            controlsPanel.SetActive(false);
            _controls = false;
        }
    }

    private void Confirm()
    {
        if (Gamepad.all[0].aButton.isPressed && _confirm)
        {
            StartCoroutine(ExitGame());
            print("Exit game...");
        }
        else if (Gamepad.all[0].yButton.isPressed && _confirm)
        {
            confirmPanel.SetActive(false);
            _confirm = false;
        }
    }

    private IEnumerator WhichScene(string scene)
    {
        menuItems.SetActive(false);
        AudioManager.FadeMusic(false, true);
        Fader.FadeScene(false, true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator ExitGame()
    {
        menuItems.SetActive(false);
        AudioManager.FadeMusic(false, true);
        Fader.FadeScene(false, true);
        yield return new WaitForSeconds(2.5f);
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
           Application.Quit();
#endif
    }
}