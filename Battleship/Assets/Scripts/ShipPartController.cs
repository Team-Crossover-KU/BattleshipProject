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

    /**
    * 
    */
    private void OnTriggerEnter2D (Collider2D collision)
    {
        
    }
}
