using System;
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
            defeatPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (bossHealth <= 0)
        {
            print("VICTORY: Boss is dead!");
            bossDead = true;
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
