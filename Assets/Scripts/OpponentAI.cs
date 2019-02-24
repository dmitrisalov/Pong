using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : PaddleMovement {
    public GameObject ball;

    // Called once loaded
    private void Start() {
        // Set GameManager settings
        GameManager.instance.opponentAIScript = this;
    }

    // Using FixedUpdate() instead of Update() since we are manipulating physics
    private void FixedUpdate() {
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
