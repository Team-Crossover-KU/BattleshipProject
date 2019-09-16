using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MultiCamera info. can be found in Unity User Manual (2019.2) / Graphics / Graphics Overview / Cameras / Using more than one camera
public class CanvasScript : MonoBehaviour
{
    public Camera firstPersonCamera, overheadCamera;

    public Dropdown shipSelector;
    public Button confirmButton, startButton, returnButton, fireButton, quitButton;

    // MultiCamera info.
    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    // MultiCamera info.
    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    // Start is called before the first frame update
    public void Start()
    {
        overheadCamera = Camera.main;
        ShowOverheadView();
        shipSelector.onValueChanged.AddListener(SelectShips);
        confirmButton.onClick.AddListener(BeginShipPlacement);

        returnButton.onClick.AddListener(BackToSettings);
        startButton.onClick.AddListener(StartGame);

        quitButton.onClick.AddListener(QuitGame);
        GameReset();
    }

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

    private void BeginShipPlacement()
    {
        Debug.Log("You have clicked the Confirm button!");
        Vector3 moveToPosition = new Vector3(0, 0, 0);
        overheadCamera.transform.LookAt(moveToPosition);
        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);

        shipSelector.interactable = false;
        confirmButton.interactable = false;
        startButton.interactable = true;
        returnButton.interactable = true;
    }

    private void BackToSettings()
    {
        Debug.Log("You have clicked the Return button!");
        Vector3 moveToPosition = new Vector3(0, 0, 0);
        overheadCamera.transform.LookAt(moveToPosition);
        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);

        shipSelector.interactable = true;
        confirmButton.interactable = true;
        startButton.interactable = false;
        returnButton.interactable = false;
    }

    private void StartGame()
    {
        Debug.Log("You have clicked the Start button!");
        Vector3 moveToPosition = new Vector3(-20, 4, -805);
        overheadCamera.transform.LookAt(moveToPosition);
        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);

        startButton.interactable = false;
        returnButton.interactable = false;
        fireButton.interactable = true;
        quitButton.interactable = true;
    }

    public void QuitGame()
    {
        Debug.Log("You have clicked the Quit button!");
        GameReset();
    }

    public void GameReset()
    {
        shipSelector.interactable = true;
        shipSelector.value = 0;

        confirmButton.interactable = false;
        startButton.interactable = false;
        returnButton.interactable = false;
        fireButton.interactable = false;
        quitButton.interactable = false;
    }
}
