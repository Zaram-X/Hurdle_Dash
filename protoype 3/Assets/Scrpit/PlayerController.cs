using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References to necessary components and assets
    private Rigidbody playerRb; // Rigidbody for player movement
    public ParticleSystem explosionParticle; // Particle effect for explosion upon collision with obstacles
    public ParticleSystem dirtparticle; // Particle effect for dirt when on the ground
    private AudioSource playerAudio; // Audio source for playing sound effects
    public AudioClip jumpSound; // Sound effect for jumping
    public AudioClip crashSound; // Sound effect for crashing into obstacles
    private Animator playerAnim; // Animator for controlling animations

    // Gameplay variables
    public float jumpForce = 10; // Force applied for jumping
    public float gravityModifier; // Custom gravity modifier
    public bool isOnGround = true; // Tracks if the player is on the ground
    public bool gameOver = false; // Tracks if the game is over

    // Start is called before the first frame update
    void Start()
    {
        // Initialize references to components
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Modify the gravity for gameplay purposes
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump when the space key is pressed, the player is on the ground, and the game is not over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Apply upward force for jumping
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // Player is no longer on the ground

            // Trigger jump animation
            playerAnim.SetTrigger("Jump_trig");

            // Stop dirt particle effect while in the air
            dirtparticle.Stop();

            // Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // Handle collisions
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Set the player to be on the ground
            dirtparticle.Play(); // Play dirt particle effect
        }
        // Check if the player collides with an obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true; // Set the game over state
            Debug.Log("Game Over!"); // Log game over message

            // Trigger death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Play explosion particle effect and stop dirt particle effect
            explosionParticle.Play();
            dirtparticle.Stop();

            // Play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
