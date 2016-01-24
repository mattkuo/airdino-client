using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using SocketIO;

public class GameManager : MonoBehaviour {

	public Camera[] cameras = new Camera[3];

	public Transform[] playerRespawns = new Transform[2];

	public GameObject[] player = new GameObject[1];

	public GameObject plane1;



	// Use this for initialization
	void Start () {

		instP1 ();

    }



    // Update is called once per frame
    void Update () {
		
	}

	public void RespawnPlayer (){
		Invoke("instP1",2);

	}

	public void enableMainCam(){
		cameras [0].gameObject.SetActive(true);
	}

	void instP1(){
		GameObject p1 = (GameObject) Instantiate (plane1, playerRespawns [0].position, playerRespawns [0].rotation);
		cameras [0].gameObject.SetActive(false);
		cameras [1] = p1.GetComponentInChildren<Camera>();
		cameras [1].gameObject.SetActive(true);
		player[0] = GameObject.Find("Player 1(Clone)");
	}
}
