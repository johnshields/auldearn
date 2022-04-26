using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossTorso") && CombatManager.bossHealth >= 0)
        {
            print("Boss hit! " + CombatManager.bossHealth);
            CombatManager.bossHealth--;   
        }
    }
}
