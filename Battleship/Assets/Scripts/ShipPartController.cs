using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class ShipPartController : MonoBehaviour
{
    Collider2D collide;
    public ShipController parent;
    public bool hit = false;
    public bool bound = false;
    public SpriteRenderer rend;
    public buttonController bondTarget;
    public int partTeam;
    
    public bool partReadyToPair = false;
    


    /**
    * @pre Start is called before the first frame update.
    * @post Render the ship part at the transform location of the parent.
    * @param none
    * @return none
    */
    void Start()
    {
        parent = transform.parent.GetComponent<ShipController>();
        rend = GetComponent<SpriteRenderer>();
    }

    /**
    * Update is called once per frame.
    */
    void Update()
    {
        if (parent.isMoving)
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
    * @pre Ship part was hit.
    * @post Render the ship part at the transform location of the parent.
    * @param none
    * @return none
    */
    public void Hit()
    {
        hit = true;
        parent.hitCheck();
    }

    /**
    * @pre Ship is ready to pair to the board
    * @post allow the mouse to move the ship
    * @param none
    * @return none
    */
    private void OnMouseDown()
    {
        if (!parent.shipReadyToPair)
        {
            Debug.Log("TouchedShip");
            parent.isMoving = true;
        }

    }

    /**
    * @pre User released mouse
    * @post Parent ship isMoving flag changed to false
    * @param none
    * @return none
    */
    private void OnMouseUp()
    {
        
        if (!bound)
        parent.AttemptBond();
        parent.isMoving = false;
    }


    /**
    * @pre Another object enters a trigger collider attached to this object. 2D only.
    * @post if the collision tag is open, and if button controller's buttonTeam equals partTeam,
    * set bondTarget to collision's buttonController.
    * @param Collider2D collision
    * @return none
    */
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Open")
        {
            if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = true;
                bondTarget = collision.GetComponent<buttonController>();
            }
        }

    }

    /**
     * @pre called when two collision collider is in contact with this 
     * object's collider nearly every fram.
     * @post maintaain pairing with both colliders
     * @param Collider2D collision
     * @return none
     */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Open")
        {
            if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = true;
                bondTarget = collision.GetComponent<buttonController>();
            }
        }
    }

    /**
     * @pre Colliders between collison and this object's collider are no longer in contact.
     * @post change state of collider pairing once the colliders are no longer in contact.
     * @param Collider2D collision
     * @return none
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Open")
        {
            if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = false;
                bondTarget = null;
            }
        }
    }
}
