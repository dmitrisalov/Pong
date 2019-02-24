using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : PaddleMovement {
    public GameObject ball;

    // Using FixedUpdate() instead of Update() since we are manipulating physics
    private void FixedUpdate() {
        UpdateVelocity();

        Debug.Log(paddleRB.velocity.ToString());

        // Check if the ball is above the paddle
        if (ball.transform.position.y > gameObject.transform.position.y) {
            MoveUp();
        }
        // Check if the ball is below the paddle
        else if (ball.transform.position.y < gameObject.transform.position.y) {
            MoveDown();
        }
        else {
            StopMoving();
        }
    }
}
