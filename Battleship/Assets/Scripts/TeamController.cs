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
            Ships.Add(Instantiate(ship, this.transform).GetComponent<ShipController>());
            Ships[i].SetShipLength(i+1);
            Debug.Log(i);
        }
    }

    /**
    * 
    */
    bool allShipsDestoryed()
    {
        return false;
    }
}
