using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public GameObject buttons;
    
    private void Awake()
    {
        buttons.SetActive(false);
        StartCoroutine(ActivateMenu());
    }

    private IEnumerator ActivateMenu()
    {
        yield return new WaitForSeconds(4.5f);
        buttons.SetActive(true);
        
    }
}
