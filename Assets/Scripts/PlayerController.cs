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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		IFirebase firebase = Firebase.CreateNew ("https://airdino.firebaseio.com/");
//		IFirebase player = firebase.Child ("player1");


		firebase.ValueUpdated += (object sender, ChangedEventArgs e) => {
			Debug.Log("Updated");
		};

//		firebase.ChildAdded += (object sender, ChangedEventArgs e) => {
//			Debug.Log("Added");
//		};
//
//		firebase.ChildRemoved += (object sender, ChangedEventArgs e) => {
//			Debug.Log("Removed");
//		};
//
//		firebase.Error += (object sender, ErrorEventArgs e) => {
//			Debug.Log("error");
//		};

			
//		player. += (object sender, ChangedEventArgs e) => {
//			
//			Dictionary<string, object> dict = e.DataSnapshot.DictionaryValue;
//			Debug.Log(e.DataSnapshot.ToString);
//
//			foreach(KeyValuePair<string, object> entry in dict) {
//				Debug.LogFormat("String: {0} Object: {1}", entry.Key, entry.Value);
//			}
//		};
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
}