using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public BallMovement ballMovementScript;
    public PlayerMovement playerMovementScript;
    public OpponentAI opponentAIScript;

    private int playerScore;
    private int opponentScore;

    // Gets called when GameManager is loaded
    private void Awake() {
        // Sets the static instance of the manager to 'this' if not already set
        if (instance == null) {
            instance = this;
            // Prevent this from getting destroyed
            DontDestroyOnLoad(gameObject);
        }
        else {
            // There is already a manager. Leave it alone and destroy this
            Destroy(gameObject);
        }

        instance.ResetScores();
    }

    public void IncreasePlayerScore() {
        playerScore++;
    }

    public void IncreaseOpponentScore() {
        opponentScore++;
    }

    public void ResetScores() {
        playerScore = 0;
        opponentScore = 0;
    }

    public Vector2 GetScores() {
        return new Vector2(playerScore, opponentScore);
    }

    public void NewRound() {
        // Reset the ball and opponent. Feels weird to reset player
        ballMovementScript.ResetBall();
        //playerMovementScript.Reset();
        opponentAIScript.ResetPaddle();
    }
}
