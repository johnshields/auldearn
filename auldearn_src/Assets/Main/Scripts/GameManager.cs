using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject note;

    private void Awake()
    {
        foreach (var t in Gamepad.all)
            Debug.Log(t.name);

        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    private void Update()
    {
        note.SetActive(Gamepad.all.Count == 0);
    }
}