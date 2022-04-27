using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static bool playerDead;
    public static bool bossDead;
    public GameObject victoryPanel, defeatPanel;
    
    private void Update()
    {
        if (playerHealth <= 0)
        {
            print("DEFEAT: Player is dead!");
            playerDead = true;
            StartCoroutine(EndScreen(defeatPanel));
        }
        else if (bossHealth <= 0)
        {
            print("VICTORY: Boss is dead!");
            bossDead = true;
            StartCoroutine(EndScreen(victoryPanel));
        }
    }

    private static IEnumerator EndScreen(GameObject panel)
    {
        yield return new WaitForSeconds(4f);
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
