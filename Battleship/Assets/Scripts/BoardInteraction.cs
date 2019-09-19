using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardInteraction : MonoBehaviour
{
    public int hitOrMiss = 1; //0 for a miss, 1 for a hit
    public Sprite[] onClickIcons; //hit or miss icons
    public Button[] spacesAvailableBoard1; //Buttons on Board1
    public Button[] spacesAvailableBoard2; //Buttons on Board2
    public bool player1Turn = true, player2Turn = false;
    public UnityEngine.UI.Button yesButton, fireButton, confirmButton, startButton;

    // Start is called before the first frame update
    void Start()
    {

        yesButton.onClick.AddListener(YesButtonReset);
        fireButton.onClick.AddListener(FireButtonLockIn);
        confirmButton.onClick.AddListener(ConfirmButtonInteractableOff);
        startButton.onClick.AddListener(StartButtonCommencePlay);


    }

    // Update is called once per frame
    void Update()
    {

    }

    //Separate script for the buttons on the Player1 Board to place hit or miss sprites on the respected spaces
    public void BattleshipSpacesBoard1(int num)
    {
        if (player1Turn)
        {
            for(int i = 0; i < spacesAvailableBoard1.Length; i++)
            {
                if(spacesAvailableBoard1[i].image.sprite == null)
                {
                    spacesAvailableBoard1[i].interactable = true;
                }

                if (spacesAvailableBoard1[i].image.sprite == onClickIcons[2])
                {
                    spacesAvailableBoard1[i].image.sprite = null;
                    spacesAvailableBoard1[i].interactable = true;
                }
            }
            spacesAvailableBoard1[num].image.sprite = onClickIcons[2];
            spacesAvailableBoard1[num].interactable = false;
        }
    }

    //Separate script for the buttons on the Player2 Board to place hit orm iss sprites on the respected spaces
    public void BattleshipSpacesBoard2(int num)
    {
        if (player2Turn)
        {

            for (int i = 0; i < spacesAvailableBoard2.Length; i++)
            {
                if (spacesAvailableBoard2[i].image.sprite == null)
                {
                    spacesAvailableBoard2[i].interactable = true;
                }

                else if (spacesAvailableBoard2[i].image.sprite == onClickIcons[2])
                {
                    spacesAvailableBoard2[i].image.sprite = null;
                    spacesAvailableBoard2[i].interactable = true;
                }
            }


            spacesAvailableBoard2[num].image.sprite = onClickIcons[2];
            spacesAvailableBoard2[num].interactable = false;
        }
    }

    public void YesButtonReset()
    {
        for(int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            spacesAvailableBoard1[i].interactable = true;
            spacesAvailableBoard1[i].GetComponent<Image>().sprite = null;
            spacesAvailableBoard2[i].interactable = true;
            spacesAvailableBoard2[i].GetComponent<Image>().sprite = null;
            player1Turn = true;
            player2Turn = true;
        }
    }

    public void FireButtonLockIn()
    {
        bool hasPlayed1 = false, hasPlayed2 = false;

        if (player1Turn)
        {
            for (int i = 0; i < spacesAvailableBoard1.Length; i++)
            {

                if (spacesAvailableBoard1[i].image.sprite == onClickIcons[2])
                {
                    spacesAvailableBoard1[i].image.sprite = onClickIcons[hitOrMiss];
                    hasPlayed1 = true;
                    break;
                }
            }

            for (int i = 0; i < spacesAvailableBoard1.Length; i++)
            {
                if (hasPlayed1)
                {
                    spacesAvailableBoard1[i].interactable = false;
                    if (spacesAvailableBoard2[i].image.sprite == null)
                    {
                        spacesAvailableBoard2[i].interactable = true;
                    }
                }
                else
                {
                    if (spacesAvailableBoard1[i].image.sprite == null)
                    {
                        spacesAvailableBoard1[i].interactable = true;
                    }
                }
            }

            if(hasPlayed1)
            {
                player1Turn = false;
                player2Turn = true;
            }
            else
            {
                player1Turn = true;
                player2Turn = false;
            }
        }

        else if (player2Turn)
        {
            for (int i = 0; i < spacesAvailableBoard2.Length; i++)
            {

                if (spacesAvailableBoard2[i].image.sprite == onClickIcons[2])
                {
                    spacesAvailableBoard2[i].image.sprite = onClickIcons[hitOrMiss];
                    hasPlayed2 = true;
                    break;
                }
            }

            for (int i = 0; i < spacesAvailableBoard2.Length; i++)
            {
                if (hasPlayed2)
                {
                    spacesAvailableBoard2[i].interactable = false;
                    if (spacesAvailableBoard1[i].image.sprite == null)
                    {
                        spacesAvailableBoard1[i].interactable = true;
                    }
                }
                else
                {
                    if (spacesAvailableBoard2[i].image.sprite == null)
                    {
                        spacesAvailableBoard2[i].interactable = true;
                    }
                }
            }

            if (hasPlayed2)
            {
                player1Turn = true;
                player2Turn = false;
            }
            else
            {
                player1Turn = false;
                player2Turn = true;
            }
        }
    }

    public void ConfirmButtonInteractableOff()
    {
        for(int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            spacesAvailableBoard1[i].interactable = false;
            spacesAvailableBoard2[i].interactable = false;
        }
    }

    public void StartButtonCommencePlay()
    {
        for(int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            spacesAvailableBoard1[i].interactable = true;
            spacesAvailableBoard2[i].interactable = false;
            spacesAvailableBoard1[i].image.sprite = null;
            spacesAvailableBoard2[i].image.sprite = null;


        }
    }
}
