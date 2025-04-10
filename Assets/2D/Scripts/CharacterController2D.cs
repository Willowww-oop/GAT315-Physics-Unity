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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;
        direction.x = Input.GetAxis("Horizontal");

        force = direction * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }


        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        if (direction.x > 0.05f) spriteRenderer.flipX = false;
        if (direction.x < -0.05f) spriteRenderer.flipX = true;

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);

        //rb.AddForce(force, ForceMode2D.Force);
    }
}

