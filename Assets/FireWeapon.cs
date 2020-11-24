using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] ParticleSystem particleFeedback;
    [SerializeField] int weaponDamage = 20;
    [SerializeField] LayerMask hitLayers;

    [SerializeField] AudioSource _gunshot;

    RaycastHit objectHit;


    //Cameras
    public Camera camera1;
    public Camera camera2;

    private void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;

        AudioSource _gunshot = GetComponent<AudioSource>();
        ParticleSystem particlefeedback = GetComponent<ParticleSystem>();

    }



    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
            _gunshot.Play();
        }
    }

    void Shoot()
    {
        //calculate direction to shoot the ray
        //cast a debug ray
        //do the raycast detection
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.red, 1f);

        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
        {
            Debug.Log("You HIT the " + objectHit.transform.name);

            if (objectHit.transform.tag == "Ground")
            {
                Debug.Log("Deal Damage");
                //Visual Feedback
                visualFeedbackObject.transform.position = objectHit.point;
                particleFeedback.Play();

                //Apply damage if it's enemy
                //EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                //if (enemyShooter != null)
                {
                    // enemyShooter.TakeDamage(weaponDamage);
                }
            }
        }
        else
        {
            Debug.Log("Miss.");
        }




    }
}
