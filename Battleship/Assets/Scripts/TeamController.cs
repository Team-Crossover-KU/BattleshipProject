using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class TeamController : MonoBehaviour
{
    public List<ShipController> Ships;
    public int numberOfShips;
    bool isNumShipsSelected = false;
    public GameObject ship;
    public bool loseCheck = false;
    public bool placeCheck = false;
    public int team = 0;
    public int shipsLeft = 0;

    /**
    * Start is called before the first frame update.
    */
    void Start()
    {

    }

    /**
    * Update is called once per frame.
    */
    void Update()
    {
        if (isNumShipsSelected == false && numberOfShips > 0)
        {
            spawnShips(numberOfShips);
            isNumShipsSelected = true;
            shipsLeft = numberOfShips;
        }
    }

    /**
    * 
    */
    public void SetNumberOfShips(int shipAmmount)
    {
        numberOfShips = shipAmmount;
    }

    /**
    * 
    */
    void spawnShips(int length)
    {
        for (int i = 0; numberOfShips > i; i++)
        {
            Ships.Add(Instantiate(ship, this.transform.position,Quaternion.identity,this.transform).GetComponent<ShipController>());
            Ships[i].transform.position = new Vector3(this.transform.position.x, 
                                                      this.transform.position.y + i * 30, 
                                                      this.transform.position.z);
            Ships[i].SetShipLength(i+1);
            Ships[i].shipTeam = team;
            Debug.Log(i);
        }
    }

    public void checkForLoss()
    {
        loseCheck = true;
        shipsLeft = 0;
        foreach (ShipController ship in Ships)
        {
            if (!ship.destoryCheck)
            {
                loseCheck = false;
                shipsLeft++;
            }
        }

        
    }

    public void disappearShips()
    {
        foreach (ShipController ship in Ships)
        {
            ship.disappear();
        }
    }

    public void appearShips()
    {
        foreach (ShipController ship in Ships)
        {
            ship.appear();
        }
    }

    public void checkPlacement()
    {
        placeCheck = true;
        foreach (ShipController ship in Ships)
        {
            if (!ship.shipReadyToPair)
            {
                placeCheck = false;

            }
        }
    }


    /**
    * 
    */

}
