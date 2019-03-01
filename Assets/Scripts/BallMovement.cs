﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    //public GameManager gameManager;
    public Score playerScore;               // Used for updating score
    public float secondsToWait = 1.5f;
    public float initialXVelocity = -15f;
    public float initialYVelocity = -7.5f;
    public float leftResetPosition = -25;   // Ball resets at this point
    public float rightResetPosition = 25;   // Ball resets at this point

    //protected Transform ball;           // For easier readability
    private Vector2 initialPosition;
    protected float currentXVelocity;   // This keeps track of x direction
    protected float currentYVelocity;   // This keeps track of y direction
    protected float positiveYVelocity;  // Absolute value of Y velocity

    // Start is called before the first frame update
    private void Start() {
        positiveYVelocity = Mathf.Abs(initialYVelocity);

        // Get the transform component of the ball
        initialPosition = transform.position;
        ResetBall();
    }

    public void ResetBall() {
        // Reset the ball to the initial position
        transform.position = initialPosition;
        
        // Set velocities to 0 to keep the ball from moving
        currentXVelocity = 0;
        currentYVelocity = 0;

        // Wait for a bit to give the user some time to readjust, then start
        StartCoroutine(WaitAndReset());
    }

    IEnumerator WaitAndReset() {
        yield return new WaitForSeconds(secondsToWait);

        // Start the balls movement in the initial velocity
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
            if (paddle.position.y < transform.position.y) {
                // Vertical velocity is set to positive
                currentYVelocity = positiveYVelocity;
            }
            // Check if the ball collided with the bottom half (or exact center)
            else {
                // Vertical velocity is set to negative
                currentYVelocity = -positiveYVelocity;
            }
        }

        // Check if ball hit an obstacle
        if (otherObject.collider.tag == "Obstacle") {
            ResetBall();
            playerScore.Reset();
        }
    }

    /* Return a new velocity vector based on currentXVelocity and
    currentYVelocity. Time.deltaTime is used to preserve speed given different
    framerates. */
    protected Vector2 UpdatedVelocity() {
        return new Vector2(currentXVelocity * Time.deltaTime, 
            currentYVelocity * Time.deltaTime);
    }
}
