using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*
 * MainMenu
 * Script that controls the MainMenu UI interaction.
 */
public class MainMenu : MonoBehaviour
{
    public GameObject menuItems, confirmPanel, controlsPanel, muteBtn, unMuteBtn, credits;
    private bool _confirm, _controls, _credits;

    public void Awake()
    {
        AudioManager.MuteActive();
        confirmPanel.SetActive(false);
        credits.SetActive(false);
        _confirm = false;
        _controls = false;
        _credits = false;

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
            if (Gamepad.all[0].aButton.isPressed && !_confirm && !_controls && !_credits)
            {
                StartCoroutine(WhichScene("02_AuldearnBattle"));
            }
            // Controls Menu
            else if (Gamepad.all[0].xButton.isPressed && !_confirm && !_controls && !_credits)
            {
                _controls = true;
            }
            // Credits
            else if (Gamepad.all[0].rightShoulder.isPressed && !_confirm && !_controls && !_credits)
            {
                _credits = true;
            }
            // Confirm Exit.
            else if (Gamepad.all[0].bButton.isPressed && !_confirm && !_controls && !_credits)
            {
                _confirm = true;
            }
            // Mute Game
            else if (Gamepad.all[0].dpad.left.isPressed && !_confirm && !_controls && !_credits)
            {
                Bools.muteActive = true;
                muteBtn.SetActive(false);
                unMuteBtn.SetActive(true);
                AudioManager.MuteActive();
            }
            else if (Gamepad.all[0].dpad.right.isPressed && !_confirm && !_controls && !_credits)
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
            else if (_credits)
            {
                credits.SetActive(true);
                credits.GetComponent<Animator>().SetBool("RollCredits", true);
                credits.GetComponent<Animator>().SetBool("Fin", false);
                StartCoroutine(EndCredits());
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

    private IEnumerator EndCredits()
    {
        yield return new WaitForSeconds(20f);
        credits.SetActive(false);
        _credits = false;
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