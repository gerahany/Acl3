using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public int healingAmount = 10; // Amount to heal when collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            BasePlayer player = other.GetComponent<BasePlayer>();
            if (player != null)
            {
                player.AddPotion(); // Add potion to the player's inventory
                Destroy(gameObject); // Destroy the potion
            }
        }
    }
}
