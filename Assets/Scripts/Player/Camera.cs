using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour, InputController.ICameraInputActions
{
    public static Camera instance;
    float mouseSensibility = 2f;
    public Transform player;
    public List<GameObject> cameras = new List<GameObject>();
    private InputController ic;
    public int activeCam;

    public GameObject head;
    bool headActive = true;
    void Awake()
    {
        ic = new InputController();
        ic.CameraInput.SetCallbacks(this);

        Cursor.lockState = CursorLockMode.Locked;
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
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
                    head.SetActive(true);
                    break;
                case 1:
                    cameras[2].SetActive(true);
                    cameras[1].SetActive(false);
                    activeCam = 2;
                    head.SetActive(true);
                    break;
                case 2:
                    cameras[0].SetActive(true);
                    cameras[2].SetActive(false);
                    activeCam = 0;
                    StartCoroutine(HeadOff());
                    break;
            }
        }
    }
    IEnumerator HeadOff()
    {
        yield return new WaitForSeconds(1);
        head.SetActive(false);
        headActive = false;
    }
}
