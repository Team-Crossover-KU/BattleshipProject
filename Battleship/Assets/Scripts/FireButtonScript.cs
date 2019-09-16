using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireButtonScript : MonoBehaviour
{
    public Button fireButton;
    // Use this for initialization
    void Start()
    {
        fireButton.onClick.AddListener(FireAtCoordiantes);
    }

    private void FireAtCoordiantes()
    {
        Debug.Log("Fire!");
    }
}
