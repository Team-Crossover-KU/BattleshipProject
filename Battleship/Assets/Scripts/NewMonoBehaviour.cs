using UnityEngine;
using System.Collections;

// MultiCamera info. can be found in Unity User Manual (2019.2) / Graphics / Graphics Overview / Cameras / Using more than one camera
public class NewMonoBehaviour : MonoBehaviour
{
    public Camera firstPersonCamera, overheadCamera;

    // MultiCamera info.
    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    // MultiCamera info.
    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        overheadCamera = Camera.main;
        ShowOverheadView();
    }

    void CameraPositionTransform(int x, int y, int z)
    {
        Vector3 moveToPosition = new Vector3(x, y, z);
        overheadCamera.transform.LookAt(moveToPosition);
        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);
    }
}
