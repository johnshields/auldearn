using UnityEngine;

/*
 * BossCombat
 * Attached to Boss' Fists - triggered when they hit player.
 */
public class BossCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CombatManager.playerHealth >= 0 && !PlayerAnimAndSound.dodgeActive)
            CombatManager.playerHealth--;
    }
}