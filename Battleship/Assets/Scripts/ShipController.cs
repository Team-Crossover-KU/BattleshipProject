using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class ShipController : MonoBehaviour
{
    bool allPartsDestroyed = false;
    bool isSpawned = false;
    public List<ShipPartController> parts;
    public int shipLength = 0;
    public GameObject shipPart;

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
        //spawn
        if (isSpawned == false && shipLength > 0)
        {
            Spawn();
            isSpawned = true;
        }
    }

    /**
    * for n length, spawn ship parts 
    */
    void Spawn()
    {
        //for loop for spawning
        for (int i = 0; shipLength > i; i++)
        {
            parts.Add(Instantiate(shipPart, this.transform).GetComponent<ShipPartController>());
            parts[i].transform.position = new Vector3(i * shipPart.transform.localScale.x, 0, 0);
            Debug.Log(i);
        }
    }

    /**
    * setter for ship length.
    */
    public void SetShipLength(int n)
    {
        shipLength = n;
    }

    /**
    * Check.
    */
    void checkParts()
    {

    }


    













}
