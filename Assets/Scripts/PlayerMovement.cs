using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PaddleMovement
{
    // Runs every frame.
    private void Update()
    {
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
    }
}