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
    public bool activeCam = true;

    public GameObject head;
    bool headActive = true;
    void Awake()
    {
        ic = new InputController();
        ic.CameraInput.SetCallbacks(this);

        Cursor.lockState = CursorLockMode.Locked;
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
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensibility;

            player.Rotate(Vector3.up * mouseX);
        }
    }
    public void OnChangeCamera(InputAction.CallbackContext context)
    {
        //there are 2 cams, 3rd and 1st person.
        if (context.performed)
        {
            activeCam = !activeCam;
            if (!activeCam)
            {
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                StartCoroutine(HeadOff());
            }
            else
            {
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                head.SetActive(true);
                headActive = true;
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
