using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        foreach (var t in Gamepad.all)
            Debug.Log(t.name);
        
        Time.timeScale = 1f;
    }
    
}