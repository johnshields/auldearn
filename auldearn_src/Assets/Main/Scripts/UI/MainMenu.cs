using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject confirmPanel;
    private bool _confirm;

    public void Awake()
    {
        foreach (var t in Gamepad.all)
            Debug.Log(t.name);


        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        _confirm = false;
    }

    private void Update()
    {
        if (EnableMenu.menuActive)
        {
            if (Gamepad.all.Count <= 0) return;
            if (Gamepad.all[0].aButton.isPressed && !_confirm)
            {
                SceneManager.LoadScene("TestBox");
            }
            else if (Gamepad.all[0].bButton.isPressed && !_confirm)
            {
                print("Waiting confirmation...");
                _confirm = true;
            }
            else if (_confirm)
            {
                confirmPanel.SetActive(true);
                if (Gamepad.all[0].aButton.isPressed && _confirm)
                {
                    print("Exit game...");
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
           Application.Quit();
#endif
                }
                else if (Gamepad.all[0].yButton.isPressed && _confirm)
                {
                    confirmPanel.SetActive(false);
                    _confirm = false;
                }
            }   
        }
    }
}