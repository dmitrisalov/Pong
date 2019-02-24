using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public BallMovement ballMovementScript;
    public PlayerMovement playerMovementScript;
    public OpponentAI opponentAIScript;

    private int playerScore;
    private int opponentScore;

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
        ballMovementScript.ResetBall();
    }

    private void LoadMenu() {
        // Load the Main_Menu scene. This results in lost progress.
        SceneManager.LoadScene("Main_Menu");
    }

    private void Update() {
        // Check if 'esc' is pressed
        if (Input.GetKey("escape")) {
            LoadMenu();
        }
    }
}
