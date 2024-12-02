using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
     public GameObject potionPrefab; // Assign the Healing Potion prefab
    // public TMP_Text textPrefab; // Assign a TMP_Text prefab in the Inspector
    public Vector3 globalXRange = new Vector3(0, 100); // Global X range (min, max)
    public Vector3 globalZRange = new Vector3(0, 100); // Global Z range (min, max)
    public float yPosition = 16f; // Fixed Y position for spawning potions
    public int potionsToSpawn = 50; // Total number of potions to scatter
    public float minDistance = 1f; // Minimum distance between potions
    public float collisionCheckRadius = 0.5f; // Radius to check for collisions

    private List<Vector3> usedPositions = new List<Vector3>(); // Tracks used positions

    void Start()
    {
        SpawnPotionsGlobally();
    }

    void SpawnPotionsGlobally()
    {
        int spawned = 0;

        while (spawned < potionsToSpawn)
        {
            // Generate a random position within the global range
            float randomX = Random.Range(globalXRange.x, globalXRange.y);
            float randomZ = Random.Range(globalZRange.x, globalZRange.y);
            Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);

            // Check if the position is valid and does not collide with anything
            if (IsPositionValid(spawnPosition) && IsPositionFreeOfObstacles(spawnPosition))
            {
                // Instantiate the potion prefab at the valid position
                GameObject potion = Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
                usedPositions.Add(spawnPosition); // Add the position to the list of used positions

                // Add a text label above the potion
                // AddTextLabel(potion.transform.position, "Healing Potion");
                spawned++;
            }
        }
    }

    // void AddTextLabel(Vector3 position, string labelText)
    // {
    //     // Adjust the position slightly above the potion
    //     Vector3 textPosition = position + new Vector3(0, 1.5f, 0); // 1.5 units above the potion

    //     // Instantiate the text prefab and set its text
    //     TMP_Text textObject = Instantiate(textPrefab, textPosition, Quaternion.identity);
    //     textObject.text = labelText; // Set the label text
    // }

    bool IsPositionValid(Vector3 position)
    {
        // Ensure the position is not too close to any already used positions
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }

    bool IsPositionFreeOfObstacles(Vector3 position)
    {
        // Check if there are obstacles at the position using Physics.CheckSphere
        Collider[] colliders = Physics.OverlapSphere(position, collisionCheckRadius);

        // If there are any colliders within the radius, the position is not free
        if (colliders.Length > 0)
        {
            Debug.Log($"Position {position} is blocked by an obstacle.");
            return false;
        }

        return true; // Position is free of obstacles
    }
}
