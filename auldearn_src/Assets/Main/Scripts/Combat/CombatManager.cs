using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static bool playerDead, bossDead, gameOver;
    public AudioClip[] deathSFX;
    public GameObject victoryPanel, defeatPanel;
    public GameObject btnOptions;
    private AudioSource _audio;
    private GameObject _pHealthUI, _bHealthUI;
    private bool _played;

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
        _audio = GetComponent<AudioSource>();
        _pHealthUI = GameObject.Find("HUD/Canvas/Health/pHealthTxt");
        _bHealthUI = GameObject.Find("HUD/Canvas/Health/bHealthTxt");
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            playerDead = true;
            StartCoroutine(EndScreen(defeatPanel, 0));
        }
        else if (bossHealth <= 0)
        {
            bossDead = true;
            StartCoroutine(EndScreen(victoryPanel, 1));
        }
    }

    private void OnGUI()
    {
        var pHealthUI = _pHealthUI.GetComponent<Text>();
        var bHealthUI = _bHealthUI.GetComponent<Text>();
        pHealthUI.text = "KNIGHT: " + playerHealth;
        bHealthUI.text = "AULDEARN: " + bossHealth;
    }

    private IEnumerator EndScreen(GameObject panel, int sound)
    {
        yield return new WaitForSeconds(1f);
        if (!_played)
        {
            _audio.PlayOneShot(deathSFX[sound]);
            _played = true;
        }

        yield return new WaitForSeconds(3f);
        panel.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameOver = true;
        btnOptions.SetActive(true);
        Time.timeScale = 0f;
    }
}