using UnityEngine;
using System.Collections;

public class CameraEnd : MonoBehaviour {

	public GameObject cameraEnd;
	public int speed = 10;
	
	// Update is called once per frame
	void Update () {
	
		camera.transform.Translate (Vector3.down *Time.deltaTime * speed);
	}
}
