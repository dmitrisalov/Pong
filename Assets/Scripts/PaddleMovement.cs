using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Used for boundaries for paddles.
    public Camera cam;
    public float movementSpeed = 6.75f;

    private float currentSpeed;
    private float currVerticalVelocity;

    protected void MoveUp()
    {
        // Check if the paddle has NOT collided with the top.
        if (!PaddleCollidedWithTop())
        {
            // Set the velocity to vertical.
            currVerticalVelocity = movementSpeed;

            // Move the paddle.
            transform.Translate(UpdatedVelocity());
        }
    }

    protected void MoveDown()
    {
        // Check if the paddle has NOT collided with the bottom.
        if (!PaddleCollidedWithBottom())
        {
            // Set the velocity to vertical.
            currVerticalVelocity = -movementSpeed;

            // Move the paddle.
            transform.Translate(UpdatedVelocity());
        }
    }

    protected void StopMoving()
    {
        currVerticalVelocity = 0;

        // Move the paddle.
        transform.Translate(UpdatedVelocity());
    }

    private bool PaddleCollidedWithTop()
    {
        // Calculate the position of the top edge of the ball.
        float topEdge = transform.position.y + (transform.localScale.y / 2f);
        var topEdgePosition = new Vector2(0, topEdge);

        // Return true if the screen position of the ball is at the top.
        return cam.WorldToScreenPoint(topEdgePosition).y >= cam.pixelHeight;
    }

    private bool PaddleCollidedWithBottom()
    {
        // Calculate the position of the top edge of the ball.
        float bottomEdge = transform.position.y - (transform.localScale.y / 2f);
        var bottomEdgePosition = new Vector2(0, bottomEdge);

        // Return true if the screen position of the ball is at the top.
        return cam.WorldToScreenPoint(bottomEdgePosition).y <= 0;
    }

    // Set the vertical velocity vector using movementSpeed. 
    // Time.deltaTime allows for speed to stay the same given different frame rates.
    private Vector2 UpdatedVelocity()
    {
        return new Vector2(0, currVerticalVelocity * Time.deltaTime);
    }
}