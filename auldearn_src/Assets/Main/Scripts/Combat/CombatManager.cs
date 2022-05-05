using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static bool playerDead, bossDead, gameOver;
    public AudioClip[] deathSFX;
    public GameObject victoryPanel, defeatPanel, playerHB, bossHB;
    public GameObject btnOptions;
    public GameObject bars;
    public GameObject[] fills;
    private AudioSource _audio;
    private bool _played;
    private Slider _playerHealthBar, _bossHealthBar;
    public int[] cheatHealth;

    private void Awake()
    {
        // reset
        cheatHealth[0] = 5;
        cheatHealth[1] = 5;
        playerHealth = 30;
        bossHealth = 50;
        gameOver = false;
        playerDead = false;
        bossDead = false;
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _playerHealthBar = playerHB.GetComponent<Slider>();
        _bossHealthBar = bossHB.GetComponent<Slider>();
    }

    private void Update()
    {
        // For testing.
        if (cheatHealth[0] == 0)
            playerHealth = 0;
        else if (cheatHealth[1] == 0)
            bossHealth = 0;
        
        // End Game if Player or Boss Health goes to 0.
        if (playerHealth <= 0)
        {
            playerDead = true;
            fills[0].SetActive(false);
            StartCoroutine(EndScreen(defeatPanel, 0));
        }
        else if (bossHealth <= 0)
        {
            bossDead = true;
            fills[1].SetActive(false);
            StartCoroutine(EndScreen(victoryPanel, 1));
        }

        HealthBars();
    }

    private void HealthBars()
    {
        _playerHealthBar.value = playerHealth;
        _bossHealthBar.value = bossHealth;
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
        bars.SetActive(false);
        yield return new WaitForSeconds(5f);
        gameOver = true;
        btnOptions.SetActive(true);
    }
}