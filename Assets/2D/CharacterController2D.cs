using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 2f;

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

        var colliders = Physics.OverlapSphere(transform.position, 2);

        foreach (var collider in colliders)
        {
            Destroy(collider.gameObject);
        }

        // Debug.DrawRay(transform.position, transform.forward * 5, Color.red);

        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 5, layerMask)) Destroy(hit.collider.gameObject);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);

        //rb.AddForce(force, ForceMode2D.Force);
    }
}

