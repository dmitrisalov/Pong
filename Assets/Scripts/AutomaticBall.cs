using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticBall : BallMovement {
    public Camera cam;          // Used for limiting ball movement
    public Score opponentScore; // Used for updating opponent's score

    // Happens once per frame
    private void Update() {
        // Check if ball hit the top of the screen
        if (BallCollidedWithTop()) {
            // Set Y velocity to negative
            currentYVelocity = -positiveYVelocity;
        }

        // Check if ball hit the bottom of the screen
        if (BallCollidedWithBottom()) {
            // Set Y velocity to positive
            currentYVelocity = positiveYVelocity;
        }

        // Check and handle if the ball goes out of bounds
        CheckOutOfBounds();

        // Move the ball
        transform.Translate(UpdatedVelocity());
    }

    private void CheckOutOfBounds() {
        // Check if ball is out of bounds on left side
        if (transform.position.x < leftResetPosition) {
            // The ball went past the player, so opponent increases score
            opponentScore.Increase();
            ResetBall();
        }
        
        // Check if ball is out of bounds on right side
        if (transform.position.x > rightResetPosition) {
            // The ball went past the opponent, so player increases score
            playerScore.Increase();
            ResetBall();
        }
    }

    private bool BallCollidedWithTop() {
        // Calculate the position of the top edge of the ball
        float topEdge = transform.position.y + (transform.localScale.y / 2f);
        Vector2 topEdgePosition = new Vector2(0, topEdge);

        // Return true if the screen position of the ball is at the top
        return cam.WorldToScreenPoint(topEdgePosition).y >= cam.pixelHeight;
    }

    private bool BallCollidedWithBottom() {
        // Calculate the position of the bottom edge of the ball
        float bottomEdge = transform.position.y - (transform.localScale.y / 2f);
        Vector2 bottomEdgePosition = new Vector2(0, bottomEdge);

        // Return true if the screen position of the ball is at the bottom
        return cam.WorldToScreenPoint(bottomEdgePosition).y <= 0;
    }
}
