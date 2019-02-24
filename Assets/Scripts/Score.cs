using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public GameManager gameManager;
    public GameObject playerScore;
    public GameObject opponentScore;

    private Text playerScoreText;
    private Text opponentScoreText;

    // Start is called before the first frame update
    void Start() {
        // Get the text components for the scores
        playerScoreText = playerScore.GetComponent<Text>();
        opponentScoreText = opponentScore.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        // Update the scores
        Vector2 scores = gameManager.GetScores();
        playerScoreText.text = scores.x.ToString();
        opponentScoreText.text = scores.y.ToString();
    }
}
