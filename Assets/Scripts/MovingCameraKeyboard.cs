using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraKeyboard : MonoBehaviour {

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
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

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

        mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

    }
}
