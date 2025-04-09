using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputController.IPlayerInputActions, IDamage
{
    public static Player instance;
    internal Rigidbody rb;
    public float speed = 7.5f;
    private InputController ic;
    public GameObject weapon, bulletPrefab;
    public Stack<GameObject> bullets;
    
    public bool isGrounded;

    public float HP { get; set; }

    private void Awake()
    {
        instance = this;
        HP = 10;
        rb = GetComponent<Rigidbody>();
        ic = new InputController();
        ic.PlayerInput.SetCallbacks(this);
        bullets = new Stack<GameObject>();
    }
    private void OnEnable()
    {
        ic.PlayerInput.Enable();
    }
    private void OnDisable()
    {
        ic.PlayerInput.Disable();
    }
    private void Update()
    {
        Move();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (bullets.Count != 0)
            {
                Pop();
            }
            else
            {
                Instantiate(bulletPrefab, weapon.transform.position, weapon.transform.rotation);
            }
        }
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = 12;
        }
        if (context.canceled)
        {
            speed = 7.5f;
        }
    }
    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
    }
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        bullets.Push(obj);
    }
    public GameObject Pop()
    {
        GameObject obj = bullets.Pop();
        obj.SetActive(true);
        Debug.Log(obj);
        obj.transform.position = weapon.transform.position;
        return obj;
    }
    public GameObject Peek()
    {
        return bullets.Peek();
    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            Application.Quit();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}