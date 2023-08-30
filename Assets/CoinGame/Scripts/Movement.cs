using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 2.0f;       
    public float runSpeed = 5.0f;        
    public float jumpForce = 5.0f;      
    public Transform groundCheck;        
    public LayerMask groundLayer;        
    public ScoreManager scoreManager;

    private Rigidbody rb;                
    private bool isGrounded;   
    public float jumpCooldown = 2.0f; 
    private float jumpCooldownTimer = 0.0f; 

          

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   void Update()
{
    isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

    float moveInputX = Input.GetAxis("Horizontal");
    float moveInputZ = Input.GetAxis("Vertical");

    float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

    Vector3 movement = new Vector3(moveInputX * speed * Time.deltaTime, 0.0f, moveInputZ * speed * Time.deltaTime);

    transform.Translate(movement);

   
    if (jumpCooldownTimer <= 0.0f)
    {
       
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCooldownTimer = jumpCooldown; 
        }
    }
    else
    {
        
        jumpCooldownTimer -= Time.deltaTime;
    }
}



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

