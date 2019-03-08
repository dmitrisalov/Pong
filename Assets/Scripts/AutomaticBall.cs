using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticBall : BallMovement
{
    // Used for limiting ball movement.
    public Camera cam;
    // Used for updating opponent's score.
    public Score opponentScore;

    // Happens once per frame.
    private void Update()
    {
        // Check if ball hit the top of the screen.
        if (CheckIfCollidedWithTop())
        {
            // Set Y velocity to negative.
            currentYVelocity = -positiveYVelocity;
        }

        // Check if ball hit the bottom of the screen.
        if (CheckIfCollidedWithBottom())
        {
            // Set Y velocity to positive.
            currentYVelocity = positiveYVelocity;
        }

        // Check and handle if the ball goes out of bounds.
        CheckIfOutOfBounds();

        // Move the ball.
        transform.Translate(UpdatedVelocity());
    }

    private void CheckIfOutOfBounds()
    {
        // Check if ball is out of bounds on left side.
        if (transform.position.x < leftResetPosition)
        {
            // The ball went past the player, so opponent increases score.
            opponentScore.IncreaseScore();
            ResetBall();
        }

        // Check if ball is out of bounds on right side.
        if (transform.position.x > rightResetPosition)
        {
            // The ball went past the opponent, so player increases score.
            playerScore.IncreaseScore();
            ResetBall();
        }
    }

    private bool CheckIfCollidedWithTop()
    {
        // Calculate the position of the top edge of the ball.
        float topEdge = transform.position.y + (transform.localScale.y / 2f);
        var topEdgePosition = new Vector2(0, topEdge);

        // Return true if the screen position of the ball is at the top.
        return cam.WorldToScreenPoint(topEdgePosition).y >= cam.pixelHeight;
    }

    private bool CheckIfCollidedWithBottom()
    {
        // Calculate the position of the bottom edge of the ball.
        float bottomEdge = transform.position.y - (transform.localScale.y / 2f);
        var bottomEdgePosition = new Vector2(0, bottomEdge);

        // Return true if the screen position of the ball is at the bottom.
        return cam.WorldToScreenPoint(bottomEdgePosition).y <= 0;
    }
}