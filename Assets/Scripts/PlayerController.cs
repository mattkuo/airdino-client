using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

	float roll = 0;
	float pitch = 0;
	float yaw = 0;

    Rigidbody rb;


	public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
		rb = this.GetComponent<Rigidbody> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

    }
	
 

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {
        Quaternion AddRot = Quaternion.identity;
        roll = Input.GetAxis("Vertical") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Vertical") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Horizontal") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        rb.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = rb.rotation * AddPos;
        rb.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
//        Debug.Log(AddPos * (Time.fixedDeltaTime * AmbientSpeed));
    }


	void OnCollisionEnter (Collision col)
	{
		Destroy(gameObject);
		gameManager.enableMainCam ();
		gameManager.RespawnPlayer ();

	}


}