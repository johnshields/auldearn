using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        foreach (var t in Gamepad.all)
            Debug.Log(t.name);
        
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    private void Update()
    {
        if (Gamepad.all.Count <= 0) return;
        if (Gamepad.all[0].aButton.isPressed)
        {
            SceneManager.LoadScene("TestBox");
        }
        else if (Gamepad.all[0].bButton.isPressed)
        {
            print("Exit game...");
            Application.Quit();
        }
    }
}