using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float rotationSpeed = 120f;

    [Header("Mode")]
    public bool rotateInsteadOfStrafe = true;
    // true  = Left/Right rotate the player
    // false = Left/Right move sideways (original behavior)

    [Header("Jumping")]
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    [SerializeField] private bool isGrounded;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Rotation mode
        if (rotateInsteadOfStrafe)
        {
            // Rotate using horizontal input
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        Vector3 move;

        if (rotateInsteadOfStrafe)
        {
            // Movement is forward/back only
            move = transform.forward * verticalInput * moveSpeed;
        }
        else
        {
            // Original WASD strafing movement
            Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            move = transform.TransformDirection(direction) * moveSpeed;
        }

        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}