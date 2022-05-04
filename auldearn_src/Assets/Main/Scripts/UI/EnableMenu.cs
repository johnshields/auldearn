using System.Collections;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public static bool menuActive;
    public GameObject buttons;

    private void Awake()
    {
        menuActive = false;
        buttons.SetActive(false);
        StartCoroutine(ActivateMenu());
    }

    private IEnumerator ActivateMenu()
    {
        yield return new WaitForSeconds(4.5f);
        buttons.SetActive(true);
        menuActive = true;
    }
}