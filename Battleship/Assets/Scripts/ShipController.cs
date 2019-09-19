using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    bool allPartsDestroyed = false;
    bool isSpawned = false;
    List<ShipPartController> parts;
    public int shipLength = 0;
    public GameObject shipPart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawn
        Spawn();
    }

    //for n length, spawn ship parts 
    void Spawn()
    {
        //for loop for spawning
    }

    //setter for ship length
    public void SetShipLength(int n)
    {
        shipLength = n;
    }

    //Check 
    void checkParts()
    {

    }


    













}
