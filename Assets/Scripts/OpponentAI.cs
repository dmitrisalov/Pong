using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : PaddleMovement {
    public Transform ball;

    // Runs every frame
    private void Update() {
        // Check if the ball is above the paddle
        if (ball.position.y > paddle.position.y) {
            MoveUp();
        }
        // Check if the ball is below the paddle
        else if (ball.position.y < paddle.position.y) {
            MoveDown();
        }
    }
}
