using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static int playerHealth = 3;
    public static int bossHealth = 5;

    private void Update()
    {
        if (playerHealth <= 0)
        {
            print("DEFEAT: Player is dead!");
        }
        else if (bossHealth <= 0)
        {
            print("VICTORY: Boss is dead!");
            BossProfiler.Death();
        }
    }
}
