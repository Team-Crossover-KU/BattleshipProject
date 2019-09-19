using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// All UI.Buttons, Dropdowns, and UI Panels set to GameObject variables derive from the UnityEngine.UI namespace Library.
// CanvasScript Contains all game transisitions from main menu, to ship placement menu, to main game interactions.
public class CanvasScript : MonoBehaviour
{
    int numShips;
    public Dropdown shipSelector;
    public UnityEngine.UI.Button confirmButton, startButton, returnButton, pauseButton, resumeButton, quitButton, yesButton, noButton, replayButton, mainMenuButton;
    public GameObject shipSelectorPanel, shipPlacementPanel, gameUIPanel, battleshipGrids, pauseMenu, gameOverMenu, confirmationPanel, gameController;
    public TeamController Team1;
    public TeamController Team2;

    // Start is called before the first frame update
    // Game will start at the main menu and all Buttons will be given event listeners onClick.
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
    // value parameter will recieve the Dropdown option value.
    private void SelectShips(int value)
    {
        value = shipSelector.value;
        Debug.Log("You have selected " + value + " ships");

        if(value > 0)
        {
            confirmButton.interactable = true;
            numShips = value;
        }
        else
        {
            confirmButton.interactable = false;
        }
    }

    // BeginShipPlacement method will disable the Ship Selection Menu and enable the Ship Placement Menu.
    // Player Grids will be set active for players to began placing their fleets.
    // Teams will be given a number of ships based on the shipSelector option value and be instaintiated within incremental sizes.
    private void BeginShipPlacement()
    {
        Debug.Log("You have clicked the Confirm button!");

        shipSelectorPanel.SetActive(false);
        shipPlacementPanel.SetActive(true);
        battleshipGrids.SetActive(true);
        Team1.SetNumberOfShips(numShips);
        Team2.SetNumberOfShips(numShips);
    }

    // BackToSettings method will return the game back to the Ship Selection Menu.
    private void BackToSettings()
    {
        Debug.Log("You have clicked the Return button!");

        shipSelectorPanel.SetActive(true);
        shipPlacementPanel.SetActive(false);
        battleshipGrids.SetActive(false);
    }

    // StartGame method will start the Battleship game once all ships have been placed.
    // Ship Placement menu will be closed and the game will proceed to the Battleship Game.
    private void StartGame()
    {
        Debug.Log("You have clicked the StartGame button!");

        shipPlacementPanel.SetActive(false);
        gameUIPanel.SetActive(true);
    }

    // PauseGame method will pull up the pause menu once the Pause button is clicked.
    private void PauseGame()
    {
        Debug.Log("You have clicked the Pause button!");
        gameUIPanel.SetActive(false);
        battleshipGrids.SetActive(false);
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
        battleshipGrids.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // QuitGame method will end the game once the user provides confirmation by clicking the Yes Button.
    // Clicking the No button will return the user back to the pause menu.
    public void QuitGame()
    {
        Debug.Log("You have clicked the Quit button!");
        confirmationPanel.SetActive(true);
        quitButton.interactable = false;
        resumeButton.interactable = false;
        //replayButton.interactable = false;
        //mainMenuButton.interactable = false;
    }

    // GameReset method will start/restart the game at the Ship Selection menu on either yesButton.onClick or at the start of the program.
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
        battleshipGrids.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        confirmationPanel.SetActive(false);
    }
}
