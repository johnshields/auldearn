using UnityEngine;

public class BossCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CombatManager.playerHealth >= 0)
        {
            print("Player hit! " + CombatManager.playerHealth);
            CombatManager.playerHealth--;
        }
    }
}
