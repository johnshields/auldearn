using System;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 30;
    public static int bossHealth = 50;
    public static GameObject boss;

    private void Start()
    {
        boss = GameObject.Find("Boss/golem");
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            print("DEFEAT: Player is dead!");
        }
        else if (bossHealth <= 0)
        {
            print("VICTORY: Boss is dead!");
            Destroy(boss);
            //BossProfiler.Death();
        }
    }
}
