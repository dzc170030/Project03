using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    public CharacterController cloneController;


    public float cloneSpeed = 12f;
    public float cloneGravity = -9.81f;
    public float cloneJumpHeight = 3f;

    public Transform cloneGroundCheck;
    public float cloneGroundDistance = 0.4f;
    public LayerMask cloneGroundMask;

    Vector3 velocity;
    bool cloneIsGrounded;

    public Camera camera2;
    public Transform storage;

    // Start is called before the first frame update

    private void Awake()
    {
        camera2 = GameObject.Find("Clone Camera").GetComponent<Camera>();
    }


    void Start()
    {

        //storage.transform.position = new Vector3(storage.transform.x, storage.transform.y, storage.transform.z);
    }

     //Update is called once per frame
     public void Update()
         {
             cloneIsGrounded = Physics.CheckSphere(cloneGroundCheck.position, cloneGroundDistance, cloneGroundMask);
             
             if (cloneIsGrounded && velocity.y < 0)
             {
                 velocity.y = -2f;
             }

        velocity.y += cloneGravity * Time.deltaTime;

        cloneController.Move(velocity * Time.deltaTime);

        if (camera2.enabled == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            cloneController.Move(move * cloneSpeed * Time.deltaTime);



            
        }
       
    }
        
    }
