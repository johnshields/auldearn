using UnityEngine;

public class BossCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CombatManager.playerHealth >= 0)
            CombatManager.playerHealth--;
    }
}