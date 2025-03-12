using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 7.5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = speed * new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y/speed, Input.GetAxis("Vertical"));
    }
}
