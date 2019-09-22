using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public ShipPartController target;
    public Collider2D collide;
    public int buttonTeam;
    // Start is called before the first frame update
    void Start()
    {
        collide = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclickhit()
    {
        if (target != null)
            target.Hit();
        else
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Something touching the board");
        if (collision.gameObject.GetComponent<ShipPartController>().partTeam == buttonTeam
            && collision.gameObject.GetComponent<ShipPartController>().parent.shipReadyToPair)
        {
            target = collision.gameObject.GetComponent<ShipPartController>();
            this.tag = "Closed";
        }
        else
        {
            Debug.Log(collision.gameObject.GetComponent<ShipPartController>().partTeam);
            Debug.Log(collision.gameObject.GetComponent<ShipPartController>().parent.shipReadyToPair);
        }
        
    }
}
