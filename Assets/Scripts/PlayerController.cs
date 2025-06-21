using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Rigidbody rb;

    private float moveDirection = 0f;
    private bool isFacingRight = true;
    private bool isGrounded = false;

    [SerializeField] private Transform groundCheck;
    private LayerMask groundLayer;
    private float groundCheckRadius;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveDirection * moveSpeed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void MoveLeft()
    {
        moveDirection = -1f;
        if (isFacingRight)
        {
            Flip();
        }
    }

    public void MoveRight()
    {
        moveDirection = 1f;
        if (!isFacingRight)
        {
            Flip();
        }
    }

    public void StopMoving()
    {
        moveDirection = 0f;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Flip()
    {
        isFacingRight =!isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
