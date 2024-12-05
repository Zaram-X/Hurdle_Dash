using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    // Reference to the obstacle prefab to be spawned
    public GameObject obstaclePrefab;

    // The position where obstacles will be spawned
    private Vector3 spwanPos = new Vector3(25, 0, 0);

    // Initial delay before spawning starts
    private float startDelay = 2;

    // Time interval between each spawn
    private float repeatRate = 2;

    // Reference to the PlayerController script to check game state
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Repeatedly call the SpwanObstacle method after the specified delay and interval
        InvokeRepeating("SpwanObstacle", startDelay, repeatRate);

        // Find and store the PlayerController script attached to the "Player" GameObject
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // No functionality required in Update for this script
    }

    // Method to spawn obstacles at the specified position
    void SpwanObstacle()
    {
        // Only spawn obstacles if the game is not over
        if (playerControllerScript.gameOver == false)
        {
            // Create a new obstacle at the spawn position with its default rotation
            Instantiate(obstaclePrefab, spwanPos, obstaclePrefab.transform.rotation);
        }
    }
}
