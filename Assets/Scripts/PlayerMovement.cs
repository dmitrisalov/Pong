using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PaddleMovement {
    // Using FixedUpdate() instead of Update() since we are manipulating physics
    private void FixedUpdate() {
        UpdateVelocity();

        // Check if player is pressing up
        if (Input.GetAxisRaw("Vertical") > 0) {
            MoveUp();
        }
        // Check if player is pressing down
        else if (Input.GetAxisRaw("Vertical") < 0) {
            MoveDown();
        }
        else {
            StopMoving();
        }
    }
}
