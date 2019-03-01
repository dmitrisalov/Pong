using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start() {
        // Get the text component for the scores
        scoreText = GetComponent<Text>();
    }

    public void Increase() {
        score++;

        // Update the display
        scoreText.text = score.ToString();
    }

    public void Reset() {
        score = 0;

        // Update the display
        scoreText.text = score.ToString();
    }

    public int GetScore() {
        return score;
    }
}
