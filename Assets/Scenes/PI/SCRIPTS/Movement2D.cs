using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{ 
    Rigidbody rb;
    
    private float horizontalInput;
    private bool grounded;
    
    public LayerMask isGround;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        CheckGrounded();
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            Debug.Log("Caca");
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (grounded)
        {
            rb.drag = 5f;
            if (moveSpeed < maxSpeed)
            {
                rb.AddForce(Vector3.right * moveSpeed * horizontalInput, ForceMode.Impulse);
            }
        }

        else if (!grounded)
            rb.drag = 0f;
            rb.AddForce(Vector3.right * moveSpeed * airMultiplier * horizontalInput, ForceMode.Impulse);

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 2 + 0.2f, isGround);
    }
}
