using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGamePlayScene()
    {
        //SceneManager.LoadScene("GamePlayScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
