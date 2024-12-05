using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    // Store the initial position of the background
    private Vector3 startPos;

    // Half of the width of the background, used to determine when to reset its position
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Save the starting position of the background
        startPos = transform.position;

        // Calculate half the width of the background using the BoxCollider component
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the background has moved far enough to the left to reset its position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // Reset the background's position to create a looping effect
            transform.position = startPos;
        }
    }
}
