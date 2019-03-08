using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : PaddleMovement
{
    public Transform ball;
    public bool ballMode = false;
    public float speedDecreaseFactor;

    // Prevents the paddle from jittering the ball is at the same height.
    private const float WIGGLE_ROOM = 0.05f;
    private float initialSpeed;

    // Runs every frame.
    private void Update()
    {
        // Check if the ball is above the paddle.
        if (ball.position.y > transform.position.y + WIGGLE_ROOM)
        {
            MoveUp();
        }
        // Check if the ball is below the paddle.
        else if (ball.position.y < transform.position.y - WIGGLE_ROOM)
        {
            MoveDown();
        }
        else
        {
            StopMoving();
        }
    }
}