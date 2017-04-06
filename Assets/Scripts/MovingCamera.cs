using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Transform playerCam, centerPoint;
    public Transform player;

    private float mouseX, mouseY;
    private float jX, jY;
    private float jSpeed = 5;

    private float zoom;
    public float zoomSpeed = 2;
    public float zoomMin = -2f;
    public float zoomMax = -10f;

    void Start()
    {
        zoom = playerCam.localPosition.z;
    }

    
    void Update()
    {
        zoom += Input.GetAxis("JZoom") * zoomSpeed;

        if (zoom > zoomMin)
            zoom = zoomMin;

        if (zoom < zoomMax)
            zoom = zoomMax;

        playerCam.transform.localPosition = new Vector3(playerCam.localPosition.x, playerCam.localPosition.y, zoom);

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");
        }

        if (Input.GetAxis("RightV") > 0.1 || Input.GetAxis("RightV") < -0.1)
        {
            jX += Input.GetAxis("RightV") * jSpeed;

        }
        if (Input.GetAxis("RightH") < 0.1 || Input.GetAxis("RightV") > -0.1)
        {
            jY += Input.GetAxis("RightH") * jSpeed;
        }

        jY = Mathf.Clamp(jY, -60f, 60f);
        playerCam.LookAt(centerPoint);
        //jX = jX - player.localRotation.y;
        //jY = jY - player.localRotation.y;
        centerPoint.localRotation = Quaternion.Euler(jY, jX, 0);
        Debug.Log(centerPoint.localRotation);

        //mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        //playerCam.LookAt(centerPoint);
        //centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

    }
}
