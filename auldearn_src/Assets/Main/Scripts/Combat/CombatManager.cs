using System;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static bool playerDead;
    public static bool bossDead;
    
    private void Update()
    {
        if (playerHealth <= 0)
        {
            print("DEFEAT: Player is dead!");
            playerDead = true;
        }
        else if (bossHealth <= 0)
        {
            print("VICTORY: Boss is dead!");
            bossDead = true;
        }
    }
}
