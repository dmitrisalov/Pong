using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayableBall : BallMovement
{
    public ObstacleGeneration obstacleGenerator;
    public Text speedText;
    // The speed at which the ball will move up and down.
    public float movementSpeed;
    public float speedIncreaseFactor = 0;
    public float topBoundPosition;
    public float bottomBoundPosition;

    // Happens once per frame.
    private void Update()
    {
        // Check if ball hit the top bound.
        if (transform.position.y >= topBoundPosition)
        {
            // Set Y position to the bound.
            transform.position = new Vector2(transform.position.x, topBoundPosition);
        }

        // Check if ball hit the bottom bound.
        if (transform.position.y <= bottomBoundPosition)
        {
            // Set Y position to the bound.
            transform.position = new Vector2(transform.position.x, bottomBoundPosition);
        }

        // Check and handle if the ball goes out of bounds.
        CheckOutOfBounds();

        // Check if player is pressing up.
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveUp();
        }
        // Check if player is pressing down.
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            MoveDown();
        }
        // Check if player is not pressing anything.
        else
        {
            StopYMovement();
        }

        // Increase the speed and display it on the screen.
        if (currentXVelocity > 0) {
            currentXVelocity += speedIncreaseFactor * Time.deltaTime;
        }
        else if (currentXVelocity < 0) {
            currentXVelocity -= speedIncreaseFactor * Time.deltaTime;
        }

        speedText.text = "Speed " + (Mathf.Abs((int)currentXVelocity)).ToString();
    }

    protected void CheckOutOfBounds()
    {
        // Check if ball goes out of bounds.
        if ((transform.position.x < leftResetPosition) || 
            (transform.position.x > rightResetPosition))
        {
            // The player has scored on a paddle.
            playerScore.IncreaseScore();
            ResetBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // Check if this is a generator trigger.
        if (trigger.tag == "Generator")
        {
            // Replace old obstacles with newly generated ones.
            obstacleGenerator.DestroyObstacles();
            obstacleGenerator.GenerateObstacles();
        }
    }

    private void MoveUp()
    {
        // Set to positive speed.
        currentYVelocity = movementSpeed;

        // Move the ball.
        transform.Translate(UpdatedVelocity());
    }

    private void MoveDown()
    {
        // Set to negative speed.
        currentYVelocity = -movementSpeed;

        // Move the ball.
        transform.Translate(UpdatedVelocity());
    }

    private void StopYMovement()
    {
        currentYVelocity = 0;

        // Move the ball.
        transform.Translate(UpdatedVelocity());
    }
}