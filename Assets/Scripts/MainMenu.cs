using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private void Update() {
        // Check if escape was pressed
        if (Input.GetKeyDown("escape")) {
            // Load the main menu
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void LoadBasic() {
        // Load the basic game mode
        SceneManager.LoadScene("Basic_Game");
    }

    public void LoadBallMode() {
        // Load the special ball mode
        SceneManager.LoadScene("Ball_Mode");
    }

    public void LoadAbout() {
        // Load the "about" page
        SceneManager.LoadScene("About_Page");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
