using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class ShipPartController : MonoBehaviour
{
    Collider2D collide;
    public bool hit = false;
    public bool isMoving = false;


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
        if (isMoving)
        {
            transform.parent.transform.position = Input.mousePosition;
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
