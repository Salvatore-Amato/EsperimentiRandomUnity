using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the player moves
    public float dashVelocity = 10f; // speed at which the player dashes
    public float dashLength = 1f; // length of the player's dash
    private Rigidbody2D rb; // reference to the player's rigidbody
    private Vector2 movement; // the movement vector
    private bool isDashing = false; // flag to determine if the player is currently dashing
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

        // check if the player is trying to dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // determine the dash direction based on the player's facing direction
            Vector2 dashDirection = transform.right;

            if (moveHorizontal < 0) // if the player is facing left
            {
                dashDirection = -transform.right;
            }
            else if (moveVertical > 0) // if the player is facing up
            {
                dashDirection = transform.up;
            }
            else if (moveVertical < 0) // if the player is facing down
            {
                dashDirection = -transform.up;
            }

            // set the movement vector to the dash velocity in the dash direction
            movement = dashDirection * dashVelocity;

            // set the flag to indicate that the player is dashing
            isDashing = true;

            // start a coroutine to end the dash after the specified dash length
            StartCoroutine(EndDash());
        }
    }

    void FixedUpdate()
    {
        // if the player is not dashing, apply the movement vector to the player's rigidbody
        if (!isDashing)
        {
            rb.velocity = movement;
        }
    }

    IEnumerator EndDash()
    {
        // wait for the specified dash length
        yield return new WaitForSeconds(dashLength);

        // reset the movement vector to zero and the flag to indicate that the player is no longer dashing
        movement = Vector2.zero;
        isDashing = false;
    }
}