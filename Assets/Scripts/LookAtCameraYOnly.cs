using UnityEngine;
using System.Collections;

public class LookAtCameraYOnly : MonoBehaviour {

	public Camera cameraToLookAt;
	
	// Update is called once per frame
	void Update () {
		Vector3 vector = cameraToLookAt.transform.position - transform.position;
		vector.x = vector.z = 0.0f;
		transform.LookAt (cameraToLookAt.transform.position - vector);
		transform.Rotate (0, 180, 0);
	}
}
