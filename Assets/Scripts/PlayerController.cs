using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        // Get input for vertical movement
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
