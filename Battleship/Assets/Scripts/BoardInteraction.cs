using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardInteraction : MonoBehaviour
{
    public int hitOrMiss = 1; //0 for a miss, 1 for a hit
    public Sprite[] impactIcons; //hit or miss icons
    public Button[] spacesAvailableBoard1; //Buttons on Board1
    public Button[] spacesAvailableBoard2; //Buttons on Board2
    public bool player1Turn = true, player2Turn = true;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
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
            spacesAvailableBoard1[num].image.sprite = impactIcons[hitOrMiss];
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
            player2Turn = true;
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
            spacesAvailableBoard2[num].image.sprite = impactIcons[hitOrMiss];
            if (hitOrMiss == 0)
            {
                hitOrMiss = 1;
            }
            else
            {
                hitOrMiss = 0;
            }
            spacesAvailableBoard2[num].interactable = false;
            player2Turn = false;
            player1Turn = true;
        }
        for (int i = 0; i < spacesAvailableBoard2.Length; i++)
        {
            spacesAvailableBoard2[i].interactable = false;
            if (spacesAvailableBoard1[i].image.sprite == null)
            {
                spacesAvailableBoard1[i].interactable = true;
            }
        }
    }
}
