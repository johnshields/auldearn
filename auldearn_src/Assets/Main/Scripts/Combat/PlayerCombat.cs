using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Boss hit! " + CombatManager.bossHealth);
        CombatManager.bossHealth--;
    }
}
