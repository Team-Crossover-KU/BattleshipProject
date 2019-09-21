using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public ShipPartController target;
    public Collider2D collide;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something touching the board");
        if (collision.gameObject.GetComponent<ShipPartController>() != null)
        target = collision.gameObject.GetComponent<ShipPartController>();
    }
}
