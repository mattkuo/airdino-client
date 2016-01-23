using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float tilt;
    public Boundary boundary;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float velocity = 5.0f;
    public float speed = 10.0f;
    public float planeLift = 1.965f;

    public float rollRate = 1.0f ;
    public float elevatorRate =1.0f;
     public float rudderRate=1.0f;


    void FixedUpdate()
    {

  
 


        rb.AddRelativeForce(Vector3.up * velocity * planeLift);

        rb.AddRelativeTorque(0, 0, -Input.GetAxis("Horizontal") * rollRate);

        rb.AddRelativeForce(0, 0, speed);

        rb.AddRelativeTorque(-Input.GetAxis("Vertical") * elevatorRate, 0, 0);
    }
}