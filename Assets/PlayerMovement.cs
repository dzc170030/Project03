using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public ParticleSystem muzzleFlash;

    Vector3 velocity;
    bool isGrounded;

    //public float health = 100;

    [SerializeField] AudioSource _gunshot;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource _gunshot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Input Functions
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprint();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSprint();

        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootGun();
            _gunshot.Play();
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Sprint()
    {
        speed = 24f;
    }

    public void StopSprint()
    {
        speed = 12f;
    }

    public void ShootGun()
    {
        muzzleFlash.Play();
    }
}
