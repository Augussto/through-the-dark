using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to change movement speed
    public float damping = 0.9f;

    private Rigidbody2D rb;

    public bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize movement to keep speed consistent in all directions
        movement.Normalize();

        // Move the player
        rb.velocity = movement * moveSpeed;

        // Apply damping if there's no input
        if (movement == Vector2.zero)
        {
            rb.velocity *= damping;
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
