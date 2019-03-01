using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private void Update() {
        // Check if 'esc' is pressed
        if (Input.GetKey("escape")) {
            LoadMenu();
        }
    }

    public void LoadMenu() {
        // Load the Main_Menu scene. You will lose your progress
        SceneManager.LoadScene("Main_Menu");
    }
}
