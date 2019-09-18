using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Dropdown shipSelector;
    public UnityEngine.UI.Button confirmButton, startButton, returnButton, pauseButton, resumeButton, quitButton, yesButton, noButton, replayButton, mainMenuButton;
    public GameObject shipSelectorPanel, shipPlacementPanel, gameUIPanel, player1Board, player2Board, pauseMenu, gameOverMenu, confirmationPanel;

    // Start is called before the first frame update
    public void Start()
    {
        GameReset();

        // Main Menu Buttons Listener Events.
        shipSelector.onValueChanged.AddListener(SelectShips);
        confirmButton.onClick.AddListener(BeginShipPlacement);

        // Ship Placement Menu Buttons Listener Events.
        returnButton.onClick.AddListener(BackToSettings);
        startButton.onClick.AddListener(StartGame);

        // Game Button Listener Events.
        pauseButton.onClick.AddListener(PauseGame);

        // Pause Menu Button Listener Events.
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);

        // Confirmation Menu Button Listener Events.
        yesButton.onClick.AddListener(GameReset);
        noButton.onClick.AddListener(PauseGame);

        // Game Over Menu Button Listener Events.
        //replayButton.onClick.AddListener(BeginShipPlacement);
        //mainMenuButton.onClick.AddListener(QuitGame);
    }

    // SelectShips method will set the confirmation button to be interactable for any selection other than the empty option.
    private void SelectShips(int value)
    {
        value = shipSelector.value;
        Debug.Log("You have selected " + value + " ships");

        if(value > 0)
        {
            confirmButton.interactable = true;
        }
        else
        {
            confirmButton.interactable = false;
        }
    }

    // BeginShipPlacement method will disable the Ship Selection Menu and enable the Ship Placement Menu.
    private void BeginShipPlacement()
    {
        Debug.Log("You have clicked the Confirm button!");

        shipSelectorPanel.SetActive(false);
        shipPlacementPanel.SetActive(true);
    }

    // BackToSettings method will return the game back to the Ship Selection Menu.
    private void BackToSettings()
    {
        Debug.Log("You have clicked the Return button!");

        shipSelectorPanel.SetActive(true);
        shipPlacementPanel.SetActive(false);
    }

    // StartGame method will start the Battleship game once all ships have been placed.
    private void StartGame()
    {
        Debug.Log("You have clicked the StartGame button!");

        shipPlacementPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        player1Board.SetActive(true);
        player2Board.SetActive(true);
    }

    // PauseGame method will pull up the pause menu once the Pause button is clicked.
    private void PauseGame()
    {
        Debug.Log("You have clicked the Pause button!");
        gameUIPanel.SetActive(false);
        player1Board.SetActive(false);
        player2Board.SetActive(false);
        pauseMenu.SetActive(true);
        confirmationPanel.SetActive(false);
        quitButton.interactable = true;
        resumeButton.interactable = true;
        //replayButton.interactable = true;
        //mainMenuButton.interactable = true;
    }

    // ResumeGame method will disable the Pause menu and return back to the game.
    private void ResumeGame()
    {
        Debug.Log("You have clicked the Resume button!");
        gameUIPanel.SetActive(true);
        player1Board.SetActive(true);
        player2Board.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // QuitGame method will end the game once the user provides confirmation.
    public void QuitGame()
    {
        Debug.Log("You have clicked the Quit button!");
        confirmationPanel.SetActive(true);
        quitButton.interactable = false;
        resumeButton.interactable = false;
        //replayButton.interactable = false;
        //mainMenuButton.interactable = false;
    }

    // GameReset method will start/restart the game at the Ship Selection menu.
    public void GameReset()
    {
        shipSelector.value = 0;

        confirmButton.interactable = false;
        quitButton.interactable = true;
        resumeButton.interactable = true;
        //replayButton.interactable = true;
        //mainMenuButton.interactable = true;

        shipSelectorPanel.SetActive(true);
        shipPlacementPanel.SetActive(false);
        gameUIPanel.SetActive(false);
        player1Board.SetActive(false);
        player2Board.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        confirmationPanel.SetActive(false);
    }
}
