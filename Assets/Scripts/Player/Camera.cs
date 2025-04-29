using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour, InputController.ICameraInputActions
{
    public static Camera instance;
    float mouseSensibility = 2f;
    public Transform player;
    public List<GameObject> cameras = new List<GameObject>();
    private InputController ic;
    public bool activeCam = true;
    public bool aiming;
    public GameObject target;
    void Awake()
    {
        instance = this;
        ic = new InputController();
        ic.CameraInput.SetCallbacks(this);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
    }
    void OnEnable()
    {
        ic.CameraInput.Enable();
    }
    void OnDisable()
    {
        ic.CameraInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensibility;

            player.Rotate(Vector3.up * mouseX);
        }

        target.SetActive(aiming);

    }
    public void OnChangeCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            aiming = true;
        }
        else if (context.canceled)
        {
            aiming = false;
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
    }
}
