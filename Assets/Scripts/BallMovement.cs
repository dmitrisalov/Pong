using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public GameManager gameManager;
    public Camera cam;
    public float initialXVelocity;
    public float initialYVelocity;
    public float leftBoundPosition;     // Ball resets at this point
    public float rightBoundPosition;    // Ball resets at this point

    private Transform ball;
    private Vector2 initialPosition;
    private float currentXVelocity;     // This keeps track of x direction
    private float currentYVelocity;     // This keeps track of y direction
    private float positiveYVelocity;    // Absolute value of Y velocity

    // Start is called before the first frame update
    private void Start() {
        positiveYVelocity = Mathf.Abs(initialYVelocity);

        // Get the transform component of the ball
        ball = transform;
        initialPosition = ball.position;
        ResetBall();
    }

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

        // Move the ball
        ball.Translate(UpdatedVelocity());

        // Check if ball is out of bounds on left side
        if (ball.position.x < leftBoundPosition) {
            // The ball went past the player, so opponent increases score
            gameManager.IncreaseOpponentScore();
            gameManager.NewRound();
        }
        
        // Check if ball is out of bounds on right side
        if (ball.position.x > rightBoundPosition) {
            // The ball went past the opponent, so player increases score
            gameManager.IncreasePlayerScore();
            gameManager.NewRound();
        }
    }

    public void ResetBall() {
        // Reset the ball to the initial position
        ball.position = initialPosition;

        // Reset velocity to the initial velocity
        currentXVelocity = initialXVelocity;
        currentYVelocity = initialYVelocity;
    }

    private void OnCollisionEnter2D(Collision2D otherObject) {
        // Check if ball has collided with a paddle
        if (otherObject.collider.tag == "Paddle") {
            // Switch the horizontal velocity
            currentXVelocity *= -1;

            // Check if the ball collided with the top half of the paddle
            Transform paddle = otherObject.collider.transform;
            if (paddle.position.y < ball.position.y) {
                // Vertical velocity is set to positive
                currentYVelocity = positiveYVelocity;
            }
            // Check if the ball collided with the bottom half (or exact center)
            else {
                // Vertical velocity is set to negative
                currentYVelocity = -positiveYVelocity;
            }
        }
    }

    private bool BallCollidedWithTop() {
        // Calculate the position of the top edge of the ball
        float topEdge = ball.position.y + (ball.localScale.y / 2f);
        Vector2 topEdgePosition = new Vector2(0, topEdge);

        // Return true if the screen position of the ball is at the top
        return cam.WorldToScreenPoint(topEdgePosition).y >= cam.pixelHeight;
    }

    private bool BallCollidedWithBottom() {
        // Calculate the position of the bottom edge of the ball
        float bottomEdge = ball.position.y - (ball.localScale.y / 2f);
        Vector2 bottomEdgePosition = new Vector2(0, bottomEdge);

        // Return true if the screen position of the ball is at the bottom
        return cam.WorldToScreenPoint(bottomEdgePosition).y <= 0;
    }

    /* Return a new velocity vector based on currentXVelocity and
    currentYVelocity. Time.deltaTime is used to preserve speed given different
    framerates. */
    private Vector2 UpdatedVelocity() {
        return new Vector2(currentXVelocity * Time.deltaTime, 
            currentYVelocity * Time.deltaTime);
    }
}
