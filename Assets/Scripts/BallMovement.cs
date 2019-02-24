using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float initialXVelocity;
    public float initialYVelocity;
    public float initialXPosition;
    public float initialYPosition;
    public float leftBoundPosition;
    public float rightBoundPosition;

    private Rigidbody2D ballRB;
    private float currentXVelocity;     // This keeps track of x direction
    private float currentYVelocity;     // This keeps track of y direction

    public void ResetBall() {
        // Reset the ball to the initial position
        gameObject.transform.position = new Vector2(initialXPosition, 
            initialYPosition);

        // Reset velocity to the initial velocity
        currentXVelocity = initialXVelocity;
        currentYVelocity = initialYVelocity;
        ballRB.velocity = UpdatedVelocityVector();
    }

    // Start is called before the first frame update
    private void Start() {
        // Sets the GameManagers ball to this
        GameManager.instance.ballMovementScript = this;

        // Get the rigidbody attached to this
        ballRB = gameObject.GetComponent<Rigidbody2D>();
        
        ResetBall();
    }

    // Happens once per frame
    private void Update() {

        // Check if ball is out of bounds on left side
        if (gameObject.transform.position.x < leftBoundPosition) {
            // The ball went past the player, so opponent increases score
            GameManager.instance.IncreaseOpponentScore();
            GameManager.instance.NewRound();
        }
        
        // Check if ball is out of bounds on right side
        if (gameObject.transform.position.x > rightBoundPosition) {
            // The ball went past the opponent, so player increases score
            GameManager.instance.IncreasePlayerScore();
            GameManager.instance.NewRound();
        }
    }

    // Using FixedUpdate() because we are directly manipulating the physics
    private void FixedUpdate() {
        /* A bug sometimes causes the y velocity to be set to 0 at the 
        boundaries. To fix this, we will give the ball a 'push' by resetting the
        y velocity. */

        // Check if y velocity is 0
        if (ballRB.velocity.y == 0) {
            // Check if on the bottom half of the screen
            if (gameObject.transform.position.y < 0) {
                // Reset to positive y velocity
                currentYVelocity = Mathf.Abs(initialYVelocity);
            }
            else {
                // Reset to negative y velocity if on the top half of the screen
                currentYVelocity = -1 * Mathf.Abs(initialYVelocity);
            }

            ballRB.velocity = UpdatedVelocityVector();
        }
    }

    private void OnCollisionEnter2D(Collision2D otherObject) {
        // Check if ball has collided with a paddle
        if (otherObject.collider.tag == "Paddle") {
            // Switch the horizontal velocity
            currentXVelocity *= -1;

            // Check if the ball collided with the top half of the paddle
            if (otherObject.collider.transform.position.y < 
                gameObject.transform.position.y) {
                // Vertical velocity is set to positive
                currentYVelocity = Mathf.Abs(currentYVelocity);
            }
            else {
                // Ball collided with bottom half. 
                // Vertical velocity is set to negative
                currentYVelocity = -1 * Mathf.Abs(currentYVelocity);
            }

            // Update the balls velocity
            ballRB.velocity = UpdatedVelocityVector();
        }
        // Check if ball has collided with a boundary
        else if (otherObject.collider.tag == "Boundary") {
            // Switch the vertical velocity and preserve horizontal velocity
            currentYVelocity *= -1;
            ballRB.velocity = UpdatedVelocityVector();
        }
    }

    /* Return a new velocity vector based on currentXVelocity and
    currentYVelocity. Time.deltaTime is used to preserve speed given different
    framerates. */
    private Vector2 UpdatedVelocityVector() {
        return new Vector2(currentXVelocity * Time.deltaTime, 
            currentYVelocity * Time.deltaTime);
    }
}
