using UnityEngine;

/// <summary>
/// Handles character movement, jumping, and coin collection.
/// </summary>
public class Movement : MonoBehaviour
{
    /// <summary>
    /// Walking speed of the character.
    /// </summary>
    public float walkSpeed = 2.0f;

    /// <summary>
    /// Running speed of the character.
    /// </summary>
    public float runSpeed = 5.0f;

    /// <summary>
    /// Jump force applied to the character.
    /// </summary>
    public float jumpForce = 5.0f;

    /// <summary>
    /// Transform used for checking if the character is grounded.
    /// </summary>
    public Transform groundCheck;

    /// <summary>
    /// Layer mask for ground detection.
    /// </summary>
    public LayerMask groundLayer;

    /// <summary>
    /// Reference to the score manager for updating the score.
    /// </summary>
    public ScoreManager scoreManager;

    private Rigidbody rb;
    private bool isGrounded;
    
    /// <summary>
    /// Cooldown time (in seconds) between jumps.
    /// </summary>
    public float jumpCooldown = 2.0f;

    private float jumpCooldownTimer = 0.0f;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
    // Check if the character is grounded
    isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

    // Get input for character movement
    float moveInputX = Input.GetAxis("Horizontal");
    float moveInputZ = Input.GetAxis("Vertical");

    // Determine movement speed (walking or running)
    float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

    // Calculate the movement vector
    Vector3 movement = new Vector3(moveInputX * speed * Time.deltaTime, 0.0f, moveInputZ * speed * Time.deltaTime);

    // Apply the movement to the character's position
    transform.Translate(movement);

    // Check if the jump cooldown timer has expired
    if (jumpCooldownTimer <= 0.0f)
    {
        // If grounded and the jump key is pressed, perform a jump and start the cooldown
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCooldownTimer = jumpCooldown;
        }
    }
    else
    {
        // Reduce the jump cooldown timer
        jumpCooldownTimer -= Time.deltaTime;
    }
}


    /// <summary>
    /// Handles coin collection and plays a sound effect.
    /// </summary>
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            scoreManager.UpdateScore(1);
            Debug.Log("Coin Collected!");
        }
    }
}



