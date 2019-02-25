using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public Camera cam;
    public float movementSpeed;
    public float initialXPosition;
    public float initialYPosition;

    protected Transform paddle;
    private float currVerticalVelocity;

    // Called before first frame
    private void Start() {
        // Get the transform component of the object
        paddle = transform;
    }

    protected void MoveUp() {
        // Check if the paddle has NOT collided with the top
        if (!PaddleCollidedWithTop()) {
            // Set the velocity to vertical
            currVerticalVelocity = movementSpeed;

            // Move the paddle
            paddle.Translate(UpdatedVelocity());
        }
    }

    protected void MoveDown() {
        // Check if the paddle has NOT collided with the bottom
        if (!PaddleCollidedWithBottom()) {
            // Set the velocity to vertical
            currVerticalVelocity = -movementSpeed;

            // Move the paddle
            paddle.Translate(UpdatedVelocity());
        }
    }

    private bool PaddleCollidedWithTop() {
        // Calculate the position of the top edge of the ball
        float topEdge = paddle.position.y + (paddle.localScale.y / 2f);
        Vector2 topEdgePosition = new Vector2(0, topEdge);

        // Return true if the screen position of the ball is at the top
        return cam.WorldToScreenPoint(topEdgePosition).y >= cam.pixelHeight;
    }

    private bool PaddleCollidedWithBottom() {
        // Calculate the position of the top edge of the ball
        float bottomEdge = paddle.position.y - (paddle.localScale.y / 2f);
        Vector2 bottomEdgePosition = new Vector2(0, bottomEdge);

        // Return true if the screen position of the ball is at the top
        return cam.WorldToScreenPoint(bottomEdgePosition).y <= 0;
    }

    /* Set the vertical velocity vector using movementSpeed. Time.deltaTime 
    allows for speed to stay the same given different frame rates */
    private Vector2 UpdatedVelocity() {
        return new Vector2(0, currVerticalVelocity * Time.deltaTime);
    }
}

