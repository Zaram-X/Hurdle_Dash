using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Speed at which objects move to the left
    private float speed = 20;

    // Reference to the PlayerController script
    private PlayerController playerControllerScript;

    // Boundary for destroying objects that move out of view
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // Locate and reference the PlayerController script on the "Player" GameObject
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is not over, continue moving the object to the left
        if (playerControllerScript.gameOver == false)
        {
            // Move the object leftwards at a consistent speed
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy the object if it moves out of bounds and is tagged as an "Obstacle"
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
