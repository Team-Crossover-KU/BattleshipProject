using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *  @class description: CanvasScript Contains all game transisitions from main menu, to ship placement menu, to main game interactions.
 *  @libraries cited: All UI.Buttons, Dropdowns, and UI Panels set to GameObject variables derive from the UnityEngine.UI namespace Library.
 */
public class CanvasScript : MonoBehaviour
{
    int numShips;
    public Dropdown shipSelector;
    public UnityEngine.UI.Button confirmButton, startButton, returnButton, pauseButton, resumeButton, quitButton, yesButton, noButton, replayButton, mainMenuButton;
    public GameObject shipSelectorPanel, shipPlacementPanel, gameUIPanel, battleshipGrids, pauseMenu, gameOverMenu, confirmationPanel, gameController;
    public TeamController Team1;
    public TeamController Team2;


    /**
    *  @pre: Start is called before the first frame update.
    *  @post: Game will start at the main menu and all Buttons will be given event listeners onClick
    */
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

    /**
    *  @pre: Program will start at the Ship Selection Menu or Ship Selection Menu is active.
    *  @param: value parameter will recieve the Dropdown option value.
    *  @post: SelectShips method will set the confirmation button to be interactable for any selection other than the empty option.
    */
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


    /**
    *  @pre: Teams will be given a number of ships based on the shipSelector option value and be instaintiated within incremental sizes.
    *  @pre: BeginShipPlacement will listen for the Confirm Button onClick event.
    *  @pre: Confirm Button is active.
    *  @post: BeginShipPlacement method will disable the Ship Selection Menu and enable the Ship Placement Menu.
    *  @post: Player Grids will be set active for players to began placing their fleets.
    *  @post: Player Fleets will be instantiated for players to place ships into the grids.
    */
    private void BeginShipPlacement()
    {
        Debug.Log("You have clicked the Confirm button!");

        shipSelectorPanel.SetActive(false);
        shipPlacementPanel.SetActive(true);
        battleshipGrids.SetActive(true);
        Team1.SetNumberOfShips(numShips);
        Team2.SetNumberOfShips(numShips);
    }

    /**
    *  @pre: BackToSettings method will listen for the Return Button onClick event.
    *  @post: BackToSettings method will return the game back to the Ship Selection Menu.
    */ 
    private void BackToSettings()
    {
        Debug.Log("You have clicked the Return button!");

        shipSelectorPanel.SetActive(true);
        shipPlacementPanel.SetActive(false);
        battleshipGrids.SetActive(false);
    }

    /**
    *  @pre: StartGame method will listen for the Start Button onClick event.
    *  @post: StartGame method will start the Battleship game once all ships have been placed.
    *  @post: Ship Placement menu will be closed and the game will proceed to the Battleship Game.
    */
    private void StartGame()
    {
        Debug.Log("You have clicked the StartGame button!");

        shipPlacementPanel.SetActive(false);
        gameUIPanel.SetActive(true);
    }

    /**
    *  @pre: PauseGame method will listen for an onClick event from either the Pause Button or the No Button.
    *  @post: PauseGame method will pull up the pause menu once the Pause button is clicked.
    */
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

    /**
    *  @pre: ResumeGame method will listen for an onClick event from the Resume Button while the Pause Menu is active.
    *  @post: ResumeGame method will disable the Pause menu and return back to the game.
    */
    private void ResumeGame()
    {
        Debug.Log("You have clicked the Resume button!");
        gameUIPanel.SetActive(true);
        battleshipGrids.SetActive(true);
        pauseMenu.SetActive(false);
    }

    /**
    *  @pre QuitGame method wil listen for an onClick event from either the Quit Button or the Main Menu Button.
    *  @post: QuitGame method will set the Confirm Selection Panel, from here the user will provide confirmation to call GameReset.
    *  @post: Clicking the No button will return the user back to the pause menu.
    */
    public void QuitGame()
    {
        Debug.Log("You have clicked the Quit button!");
        confirmationPanel.SetActive(true);
        quitButton.interactable = false;
        resumeButton.interactable = false;
        //replayButton.interactable = false;
        //mainMenuButton.interactable = false;
    }

    /**
    *  @pre: GameReset method will first be called by start to begin Battleship Game.
    *  @pre: GameReset method will listen for an onClick event from the Yes Button.
    *  @post: GameReset method will start/restart the game at the Ship Selection menu on either yesButton(dot)onClick or at the start of the program.
    */
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
