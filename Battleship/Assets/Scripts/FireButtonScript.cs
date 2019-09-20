using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* 
*/
public class FireButtonScript : MonoBehaviour
{
    public Button fireButton;

    /**
    * 
    */
    void Start()// Use this for initialization
    {
        fireButton.onClick.AddListener(FireAtCoordiantes);
    }

    /**
    * 
    */
    private void FireAtCoordiantes()
    {
        Debug.Log("Fire!");
    }
}
