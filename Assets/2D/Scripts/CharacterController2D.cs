using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    // General Player Values
    [SerializeField] float speed = 5f;
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpHeight = 5f;

    // Ground Checks
    public int jumpCount = 0;
    public int maxJumps = 1;
    public Transform groundCheck;
    public bool onGround;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    // Important Variab
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    
    Vector2 force;

    Vector2 direction;

    // Sprite Direction
    public const float FACE_LEFT = -1f;
    public const float FACE_RIGHT = 1f;
    int facing = 1; // 1 = right, -1 = left
    public int Facing => facing;

    public void OnMove(Vector2 v)
    {
        direction = v;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (groundCheck != null)
        {
            groundCheck.position = transform.position + new Vector3(0f, -1f, 0f);
        }

        // Vector2 direction = Vector2.zero;

        // direction.x = Input.GetAxis("Horizontal");

        force = direction * speed;

        animator.SetFloat("Speed", Mathf.Abs(direction.x)); 

        if (direction.x > 0.05f) spriteRenderer.flipX = false;
        else if (direction.x < -0.05f) spriteRenderer.flipX = true;

    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (onGround)
        {
            jumpCount = 0;
        }

        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);
    }

    public void OnJump()
    {
        if (onGround || jumpCount < maxJumps)
        {
            rb.AddForce(Vector2.up * Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight * rb.gravityScale), ForceMode2D.Impulse);

            animator.SetTrigger("jump");

            jumpCount++;
            onGround = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    public void OnAttack()
    {
        animator.SetTrigger("attack");
    }

    public void OnDeath()
    {
        animator.SetTrigger("death");
    }
    
    public void OnRun()
    {
        speed = runSpeed;
        //speed = 15.5f;
        animator.SetTrigger("run");
    }

    public void OnHit()
    {
        animator.SetTrigger("hurt");
    }
}

