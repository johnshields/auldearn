using UnityEngine;

public class BossCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Player hit! " + CombatManager.playerHealth);
        CombatManager.playerHealth--;
    }
}
