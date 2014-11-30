using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter (Collision col){


		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other) {

		Destroy (this.gameObject);
	}
}
