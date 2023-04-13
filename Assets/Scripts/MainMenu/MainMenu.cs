using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum MainMenuState
{
    Start,
    Initialize,
    MainMenu,
    LevelSelection,
    Store
}

public class MainMenu : MonoBehaviour
{
    private MainMenuState currentState = MainMenuState.Start;

    private void Start()
    {
        currentState = MainMenuState.Initialize;
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        switch (currentState)
        {
            case MainMenuState.Start:
                currentState = MainMenuState.Initialize; // Transition to the Initialize state
                break;
            case MainMenuState.Initialize:
                break;
            case MainMenuState.MainMenu:
                // Perform actions for the MainMenu state
                SceneManager.LoadScene("MainMenu");
                currentState = MainMenuState.Initialize;
                break;
            case MainMenuState.LevelSelection:
                SceneManager.LoadScene("LevelSelection");
                currentState = MainMenuState.Initialize; // Transition back to the Initialize state after loading the level selection
                break;
            case MainMenuState.Store:
                SceneManager.LoadScene("Store");
                currentState = MainMenuState.Initialize; // Transition back to the Initialize state after loading the store
                break;
        }
    }

    public void PlayGame()
    {
        currentState = MainMenuState.LevelSelection;
    }

    public void OpenStore()
    {
        currentState = MainMenuState.Store;
    }

    public void OpenMainMenu()
    {
        currentState = MainMenuState.MainMenu;
    }

    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}