using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class ShipPartController : MonoBehaviour
{
    Collider2D collide;
    ShipController parent;
    public bool hit = false;
    public bool isMoving = false;


    /**
    * Start is called before the first frame update.
    */
    void Start()
    {
        parent = transform.parent.GetComponent<ShipController>();
    }

    /**
    * Update is called once per frame.
    */
    void Update()
    {
        if (isMoving)
        {
            transform.parent.transform.position = Input.mousePosition;
            if (Input.GetKeyDown("a"))
            {
                parent.FaceLeft();
            }
            else if (Input.GetKeyDown("d"))
            {
                parent.FaceRight();
            }
            else if (Input.GetKeyDown("s"))
            {
                parent.FaceDown();
            }
            else if (Input.GetKeyDown("w"))
            {
                parent.FaceUp();
            }
        }
        else
        {

        }
    }

    /**
    * 
    */
    public void Hit()
    {
        hit = true;
    }

    /**
    * 
    */
    private void ResetPos()
    {

    }
    
    
    private void OnMouseDown()
    {
        Debug.Log("TouchedShip");
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
    }
    

    /**
    * 
    */
    private void OnTriggerEnter2D (Collider2D collision)
    {
        
    }
}
