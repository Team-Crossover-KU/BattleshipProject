using UnityEngine;
using System.Collections;

/**
* MultiCamera info. can be found in Unity User Manual (2019.2) / Graphics / Graphics Overview / Cameras / Using more than one camera
*/
public class NewMonoBehaviour : MonoBehaviour
{
    public Camera firstPersonCamera, overheadCamera;

    /**
    * 
    */
    public void ShowOverheadView() //MultiCamera info.
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    /**
    * 
    */
    public void ShowFirstPersonView()//MultiCamera info.
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    /**
    * 
    */
    void Start()    // Use this for initialization
    {
        overheadCamera = Camera.main;
        ShowOverheadView();
    }

    /**
    * 
    */
    void CameraPositionTransform(int x, int y, int z)
    {
        Vector3 moveToPosition = new Vector3(x, y, z);
        overheadCamera.transform.LookAt(moveToPosition);
        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);
    }
}
