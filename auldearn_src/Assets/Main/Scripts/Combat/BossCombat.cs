using UnityEngine;
using UnityEngine.UIElements;

public class BossCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player hit! " + CombatManager.playerHealth);
            CombatManager.playerHealth--;
        }
    }
}
