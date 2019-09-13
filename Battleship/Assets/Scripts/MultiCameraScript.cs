using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MultiCamera info. can be found in Unity User Manual (2019.2) / Graphics / Graphics Overview / Cameras / Using more than one camera
public class MutliCameraScript : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
