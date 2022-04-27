using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static bool playerDead;
    public static bool bossDead;
    private GameObject _pHealthUI, _bHealthUI;
    public GameObject victoryPanel, defeatPanel;
    public GameObject btnOptions;
    public static bool gameOver;

    private void Awake()
    {
        // reset
        playerHealth = 30;
        bossHealth = 50;
        gameOver = false;
        playerDead = false;
        bossDead = false;
    }

    private void Start()
    {
        _pHealthUI = GameObject.Find("HUD/Canvas/Health/pHealthTxt");
        _bHealthUI = GameObject.Find("HUD/Canvas/Health/bHealthTxt");
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            playerDead = true;
            StartCoroutine(EndScreen(defeatPanel));
        }
        else if (bossHealth <= 0)
        {
            bossDead = true;
            StartCoroutine(EndScreen(victoryPanel));
        }
    }

    private IEnumerator EndScreen(GameObject panel)
    {
        yield return new WaitForSeconds(4f);
        panel.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameOver = true;
        btnOptions.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnGUI()
    {
        var pHealthUI = _pHealthUI.GetComponent<Text>();
        var bHealthUI = _bHealthUI.GetComponent<Text>();
        pHealthUI.text = "KNIGHT: " + playerHealth;
        bHealthUI.text = "AULDEARN: " + bossHealth;
    }
}