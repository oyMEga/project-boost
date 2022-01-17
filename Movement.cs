using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //Calls the rigidbody from the object this script is attached to
        physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    //controls when the user is applying thrust to the object
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //apply thrust to y-axis
            physics.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }

    //controls when the user is applying rotation to the object
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        
        physics.freezeRotation = true; //freezing rotation so user can manually rotate

        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); //as physics engine isnt applied we can pretend boosters are causing rotation

        physics.freezeRotation = false; //unfreezing rotation so physics impacts rotate
    }
}