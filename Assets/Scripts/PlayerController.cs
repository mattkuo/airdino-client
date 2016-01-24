using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class PlayerController : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

	float roll = 0;
	float pitch = 0;
	float yaw = 0;

    float rollAxis = 0;
    float pitchAxis = 0;
    float yawAxis = 0;

    Rigidbody rb;



    GameObject go;

    SocketIOComponent socket;
    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
		rb = this.GetComponent<Rigidbody> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        socket.On("open", TestOpen);
        socket.On("gyro", (message) =>
        {
           JSONObject json =  message.data;
            JSONObject pitchJSON = json.GetField("beta");
            pitchAxis = float.Parse(pitchJSON.ToString())/180;
            JSONObject rollJSON = json.GetField("gamma");
            rollAxis = float.Parse(rollJSON.ToString())/180;
            JSONObject yawJSON = json.GetField("alpha");
            //yawAxis = float.Parse(yawJSON.ToString());
            //yawAxis = (yawAxis - 180) / 360;

            //Debug.Log("pitch: "+pitchAxis+" yaw: " +yawAxis +" Roll "+ rollAxis);
             
        });
        socket.On("error", TestError);
        socket.On("close", TestClose);

    }


    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
    }

    public void TestBoop(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

        if (e.data == null) { return; }

        Debug.Log(
            "#####################################################" +
            "THIS: " + e.data.GetField("this").str +
            "#####################################################"
        );
    }

    public void TestError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void TestClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }

    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {
        Quaternion AddRot = Quaternion.identity;
        roll = rollAxis * (Time.fixedDeltaTime * RotationSpeed);
        pitch = pitchAxis * (Time.fixedDeltaTime * RotationSpeed);
     //   yaw = yawAxis * (Time.fixedDeltaTime * RotationSpeed);
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