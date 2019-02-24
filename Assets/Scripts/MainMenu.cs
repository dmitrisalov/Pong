using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayBasicButton() {
        SceneManager.LoadScene("Basic_Game");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
