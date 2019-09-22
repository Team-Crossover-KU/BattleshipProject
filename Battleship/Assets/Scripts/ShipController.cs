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
    bool partcheck = false;
    public bool isMoving = false;
    public bool shipReadyToPair = false;
    public Vector3 startPos;
    public List<ShipPartController> parts;
    public int shipLength = 0;
    public int shipTeam = 0;
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
            startPos = transform.position;
        }

        checkParts();
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
            parts[i].transform.position = new Vector3(this.transform.position.x + i * parts[i].transform.localScale.x, 
                                                      this.transform.position.y, 
                                                      this.transform.position.z);
            parts[i].partTeam = shipTeam;
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

    public void FaceRight()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    public void FaceUp()
    {
        transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
    }

    public void FaceLeft()
    {
        transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
    }

    public void FaceDown()
    {
        transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
    }

    
    
    /**
    * Check.
    */
    public void checkParts()
    {
        if (isMoving)
        {
            partcheck = true;
            foreach (ShipPartController part in parts)
            {
                if (!part.partReadyToPair)
                {
                    partcheck = false;
                    part.rend.color = Color.red;
                }
                else
                {
                    part.rend.color = Color.green;
                }
            }
        }
        
    }

    public void AttemptBond()
    {
        if (partcheck)
        {
            shipReadyToPair = true;
        }
        else
        {
            transform.position = startPos;
            transform.rotation = Quaternion.identity;
        }


        

    }


    













}
