using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class PlayerController2DPlatformer : MonoBehaviour
{
    public float MoveSpeed = 2f;
    private Vector2 vel;
    private Vector3 Worldpos = new Vector3();
    private Vector3 mousePos = new Vector3();
    public Rigidbody rb;
    private Vector3 ang;
    public Camera cam;
     
    public void OnMove(InputAction.CallbackContext context)
    {
        vel = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        Worldpos = cam.ScreenToWorldPoint(mousePos);
        Worldpos = new Vector3(Worldpos.x, 0, Worldpos.z);
        ang = new Vector3(Worldpos.x - transform.position.x, 0, Worldpos.z - transform.position.z);
    }

    public void Movement()
    {
        Vector3 movement = new Vector3(vel.x, 0, vel.y);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ang), 0.15f);
        transform.forward = ang;

        rb.AddForce(movement * MoveSpeed * Time.deltaTime, ForceMode.Force);
    }
}
