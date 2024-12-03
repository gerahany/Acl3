using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PotionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collided
        {
            BasePlayer player = other.GetComponent<BasePlayer>();
            if (player != null)
            {
                // Only add potion and destroy it if the player's inventory is not full
                if (player.healingPotions < player.maxHealingPotions)
                {
                    player.AddPotion(); // Add potion to player's inventory
                    Destroy(gameObject); // Destroy the potion after collection
                }
                else
                {
                    Debug.Log("Potion not collected: inventory is full.");
                }
            }
        }
    }
}
