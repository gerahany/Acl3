using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public int healingAmount = 10; // Amount to heal when collected

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is a player
        if (other.CompareTag("Barbarian") || other.CompareTag("Rogue") || other.CompareTag("Sorcerer"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount); // Heal the player
                Debug.Log($"{other.tag} collected a potion and healed for {healingAmount} HP!");
                Destroy(gameObject); // Destroy the potion after collection
            }
            else
            {
                Debug.LogError($"{other.tag} does not have a PlayerHealth component!");
            }
        }
    }
}
