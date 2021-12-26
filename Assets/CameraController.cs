using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float pitch = 2f;

    public float minZoom = 5f;
    public float maxZoom = 12f;
    public float zoomSpeed = 25f;
    private float currentZoom = 10f;

    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    public float minVerticalYaw = -30f;
    public float maxVerticalYaw = 45f;
    private float verticalYaw = 0f;

    protected Vector3 localRot;
    private bool rotateWithMiddleMouse = false;
    public float rotateWithMiddleMouseSpeed = 7f;
    public float rotateWithMiddleMouseZoomSpeed = 100f;

    void Update()
    {

        if (Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(1))
        {
            rotateWithMiddleMouse = true;
        }

        if (Input.GetMouseButtonUp(2) || Input.GetMouseButtonUp(1))
        {
            rotateWithMiddleMouse = false;
        }

        if (rotateWithMiddleMouse)
        {
            if (((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) && (rotateWithMiddleMouse))
            {
                localRot.x += Input.GetAxis("Mouse X");
                localRot.y -= Input.GetAxis("Mouse Y");

                Debug.Log("x: " + localRot.x + ",y: " + localRot.y);

                currentYaw = localRot.x * rotateWithMiddleMouseSpeed;
                verticalYaw = localRot.y * rotateWithMiddleMouseSpeed;
            }

        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel");

            currentZoom -= ScrollAmount * zoomSpeed * rotateWithMiddleMouseZoomSpeed * Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        // rotate to hit
        zoomCameraUpdate();
        transform.LookAt(target.position + Vector3.up * pitch);

        // rotate around horizontal
        rotateCameraUpdate();

        // rotate around vertical
        eulerCameraUpdate();
    }

    public void rotateCamera(float turnAngle)
    {
        currentYaw -= turnAngle * yawSpeed * Time.deltaTime;
    }
    public void eulerCamera(float eulerAngle)
    {
        verticalYaw -= eulerAngle * yawSpeed * Time.deltaTime;
    }

    public void zoomCamera(float zoomAngle)
    {
        currentZoom -= zoomAngle * zoomSpeed * Time.deltaTime;
    }
    public void zoomCameraUpdate()
    {
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        transform.position = target.position - offset * currentZoom;
    }

    public void rotateCameraUpdate()
    {
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

    public void eulerCameraUpdate()
    {
        verticalYaw = Mathf.Clamp(verticalYaw, minVerticalYaw, maxVerticalYaw);
        Vector3 localX = transform.TransformDirection(Vector3.right);
        transform.RotateAround(target.position, localX, verticalYaw);
    }
}
