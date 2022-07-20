using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        string selectedCharacter = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameManager.instance.CharIndex = selectedCharacter == "Player 1" ? 0 : 1;

        SceneManager.LoadScene("Gameplay");
    }
}
