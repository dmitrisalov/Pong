using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public float movementSpeed;
    public float initialXPosition;
    public float initialYPosition;

    protected Rigidbody2D paddleRB;
    protected Vector2 verticalVelocity;
    protected Vector2 ceilingPosition;
    protected Vector2 floorPosition;

    public void ResetPaddle() {
        gameObject.transform.position = new Vector2(initialXPosition, 
            initialYPosition);
    }

    // Called when loaded
    protected void Awake() {
        paddleRB = gameObject.GetComponent<Rigidbody2D>();

        /* Set the vertical velocity vector using movementSpeed. Time.deltaTime 
        allows for speed to stay the same given different frame rates */
        verticalVelocity = new Vector2(0, movementSpeed * Time.deltaTime);

        // Set up the ceiling and floor position vectors
        float xPositition = gameObject.transform.position.x;
    }

    protected void MoveUp() {
        // Set the velocity to vertical
        paddleRB.velocity = verticalVelocity;
    }

    protected void MoveDown() {
        // Set the velocity to negative vertical
        paddleRB.velocity = -verticalVelocity;
    }

    protected void StopMoving() {
        // Set the velocity to 0
        paddleRB.velocity = Vector2.zero;
    }
}
