using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    // [SerializeField]
    // [SerializeField]
    //[SerializeField]
    //[SerializeField]

    bool player1Active = true;
    bool player2Active = false;


    bool toggleControl = false;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            toggleControl = !toggleControl;
            //Debug.Log(toggleControl = toggleControl);
        }


        
    if(toggleControl == true)
        {
            
        }






    }


}
