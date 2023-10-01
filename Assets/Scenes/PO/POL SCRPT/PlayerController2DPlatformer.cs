using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class PlayerController2DPlatformer : MonoBehaviour
{
    [Header("Values")]
    public float moveSpeed;
    private Vector2 vel;
    private Vector3 worldpos = new Vector3();
    private Vector3 mousePos = new Vector3();
    private Vector3 ang;
    [HideInInspector] public bool died;

    [Header("References")]
    public Camera cam;
    public Rigidbody rb;
    [SerializeField] GameObject cdObject;
    CountDown cd;
    [SerializeField] GameObject deathObject;
    Death death;

    private void Awake()
    {
        cd = cdObject.GetComponent<CountDown>();
        death = deathObject.GetComponent<Death>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        died = false;
    }


    void Update()
    {
        Animation();
        MouseWork();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        vel = context.ReadValue<Vector2>();
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(vel.x, 0, vel.y);

        rb.AddForce(movement * 10f * moveSpeed, ForceMode.Force);
    }



    //------------------------------------------------------------------------------------------------------------------------
            //  Mouse and animation commands to shoot in the mouse's direction
    //------------------------------------------------------------------------------------------------------------------------

    private void MouseWork()
    {
        mousePos = Input.mousePosition;
        worldpos = cam.ScreenToWorldPoint(mousePos);
        ang = new Vector3(worldpos.x - transform.position.x, 0f, worldpos.z - transform.position.z);
    }

    private void Animation()
    {
        transform.forward = ang;
    }

   

    //------------------------------------------------------------------------------------------------------------------------
            //  Player Death
    //------------------------------------------------------------------------------------------------------------------------

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (cd.hasWon != true)
        {
            if (collisioninfo.collider.tag == "bullet")
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        died = true;
        death.DisplayDeath();
    }
}
