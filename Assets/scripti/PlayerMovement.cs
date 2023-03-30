using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the player moves
    private Rigidbody2D rb; // reference to the player's rigidbody
    private Vector2 movement; // the movement vector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the player's rigidbody component
    }

    void Update()
    {
        // get input from the player's horizontal and vertical axis
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // calculate the movement vector based on the input and move speed
        movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        // check if the player is trying to move diagonally
        if (moveHorizontal != 0 && moveVertical != 0)
        {
            // reduce the movement speed by the square root of 2 to prevent the player from moving too fast
            movement *= Mathf.Sqrt(0.8f);
        }
    }

    void FixedUpdate()
    {
        // apply the movement vector to the player's rigidbody
        rb.velocity = movement;
    }
}

