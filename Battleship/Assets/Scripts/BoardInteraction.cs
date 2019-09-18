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
    public bool player1Turn = true, player2Turn = true;
    public UnityEngine.UI.Button yesButton, fireButton;

    // Start is called before the first frame update
    void Start()
    {
        Setup();

        yesButton.onClick.AddListener(YesButtonReset);
        fireButton.onClick.AddListener(FireButtonLockIn);


    }

    void Setup()
    {
        for (int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            spacesAvailableBoard1[i].interactable = true; //setting buttons for board 1 to be interactable
            spacesAvailableBoard1[i].GetComponent<Image>().sprite = null; //empty sprite, will display nothing
            spacesAvailableBoard2[i].interactable = true; //setting buttons for board 2 to be interactable
            spacesAvailableBoard2[i].GetComponent<Image>().sprite = null; //empty sprite, will display nothing
        }
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
            }
            spacesAvailableBoard1[num].image.sprite = onClickIcons[2];
            spacesAvailableBoard1[num].interactable = false;

            
            
            
            
            
            /*spacesAvailableBoard1[num].image.sprite = onClickIcons[hitOrMiss];
            if (hitOrMiss == 0)
            {
                hitOrMiss = 1;
            }
            else
            {
                hitOrMiss = 0;
            }
            spacesAvailableBoard1[num].interactable = false;
            player1Turn = false;
            player2Turn = true;*/
        }
        for(int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            spacesAvailableBoard1[i].interactable = false;
            if(spacesAvailableBoard2[i].image.sprite == null)
            {
                spacesAvailableBoard2[i].interactable = true;
            }
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

                if (spacesAvailableBoard2[i].image.sprite = onClickIcons[2])
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
        for(int i = 0; i < spacesAvailableBoard1.Length; i++)
        {
            if(spacesAvailableBoard2[i].image.sprite == onClickIcons[2])
            {
                spacesAvailableBoard2[i].image.sprite = onClickIcons[hitOrMiss];
            }

            if(spacesAvailableBoard2[i].image.sprite == null)
            {
                spacesAvailableBoard2[i].interactable = false;
            }
        }
    }
}
