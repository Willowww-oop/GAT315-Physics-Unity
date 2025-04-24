using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    Rigidbody2D rb;
    Vector2 force;

    Vector2 direction;

    public void OnMove(Vector2 v) => direction = v;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;


        // direction.x = Input.GetAxis("Horizontal");

        force = direction * speed;

        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        if (direction.x > 0.05f) spriteRenderer.flipX = false;
        if (direction.x < -0.05f) spriteRenderer.flipX = true;

    }

    public void OnJump()
    {
        rb.AddForce(Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight), ForceMode2D.Impulse);

        animator.SetTrigger("Jump");
    }

    public void OnAttack()
    {

    }

    public void OnDeath()
    {

    }
    
}

