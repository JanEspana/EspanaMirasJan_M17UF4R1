using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour, InputController.ICameraInputActions
{
    float mouseSensibility = 2f;
    public Transform player;
    public List<GameObject> cameras = new List<GameObject>();
    private InputController ic;
    int activeCam;
    void Awake()
    {
        ic = new InputController();
        ic.CameraInput.SetCallbacks(this);

        Cursor.lockState = CursorLockMode.Locked;
        activeCam = 0;
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
        cameras[2].SetActive(false);
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
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensibility;

            player.Rotate(Vector3.up * mouseX);
        }
    }

    public void OnChangeCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (activeCam)
            {
                case 0:
                    cameras[1].SetActive(true);
                    cameras[0].SetActive(false);
                    activeCam = 1;
                    break;
                case 1:
                    cameras[2].SetActive(true);
                    cameras[1].SetActive(false);
                    activeCam = 2;
                    break;
                case 2:
                    cameras[0].SetActive(true);
                    cameras[2].SetActive(false);
                    activeCam = 0;
                    break;
            }
        }
    }
}
