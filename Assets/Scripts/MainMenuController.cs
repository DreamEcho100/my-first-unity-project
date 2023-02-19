using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {
        int selectedPlayerIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedPlayerIndex;
        Debug.Log($"selectedPlayerIndex: {GameManager.instance.CharIndex}");
        SceneManager.LoadScene("GamePlayScene");
    }
}

/*

*/