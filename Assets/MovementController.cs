using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public LayerMask movementMask;
    public float range = 100f;
    Camera cam;
    PlayerController playerController;
    CameraController cameraController;

   // private float walkSpeed = 3f;
    public float turnSmoothTime = 0.1f;

    public IMetin focusMetin;

   // float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerController = GetComponent<PlayerController>();
        cameraController = cam.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerController.resetMovement();
            // movement code was here
            /*
            transform.LookAt(new Vector3(cam.transform.position.x, this.transform.position.y, cam.transform.position.z));

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(direction.magnitude >= 0.1f)
            {
                playerController.resetMovement();
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                this.transform.position += moveDir * walkSpeed * Time.deltaTime;
            }
            */
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerController.resetMovement();
            playerController.Attack();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            cameraController.rotateCamera(1f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            cameraController.rotateCamera(-1f);
        }

        if (Input.GetKey(KeyCode.R))
        {
            cameraController.zoomCamera(1f);
        }

        if (Input.GetKey(KeyCode.F))
        {
            cameraController.zoomCamera(-1f);
        }

        if (Input.GetKey(KeyCode.T))
        {
            cameraController.eulerCamera(-1f);
        }

        if (Input.GetKey(KeyCode.G))
        {
            cameraController.eulerCamera(1f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, range, movementMask))
            {
                Debug.Log("We hit 0: " + hit.collider.name + " " + hit.point);
                // Move our player to what we hit
                playerController.MoveToPoint(hit.point);
                IMetin metin = hit.collider.GetComponent<IMetin>();
                if (metin != null)
                {
                    Debug.Log("We hit 1: " + hit.collider.name + " " + hit.point);
                    SetFocus(metin);
                }
                // Stop focusing any objects
            }
        }
    }

    void SetFocus(IMetin metin)
    {
        focusMetin = metin;
        playerController.MoveToPoint(metin.transform.position);
    }

    void RemoveFocus()
    {
        focusMetin = null;
    }

}
