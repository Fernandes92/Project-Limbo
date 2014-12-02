using UnityEngine;
using System.Collections;

public class CameraPlayer : MonoBehaviour {

	public Camera cameraplayer;
	public GameObject player;

	private Vector3 heightOffSet = new Vector3 (0f, 11.26508f, -17f);
	private Vector3 initialposition = new Vector3(5.286099f, 3.167781f, -18.23361f);
	void Start(){

		player = GameObject.Find("Player");
		this.transform.position = initialposition;
	}

	void Update(){

		Vector3 _position = Vector3.zero;

		_position.x = player.transform.position.x;
		_position.y = player.transform.position.y;
		_position += heightOffSet;

		transform.position = _position;
	}

}
