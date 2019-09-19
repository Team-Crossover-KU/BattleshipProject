using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    List<ShipController> Ships;
    public int numberOfShips;
    bool isNumShipsSelected = false;
    public GameObject ship;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isNumShipsSelected == false && numberOfShips > 0)
        {
            Instantiate(ship, this.transform);
            isNumShipsSelected = true;
        }

    }

    public void SetNumberOfShips(int shipAmmount)
    {
        numberOfShips = shipAmmount;
    }

    void spawnShips(int length)
    {

    }

    bool allShipsDestoryed()
    {
        return false;
    }
}
