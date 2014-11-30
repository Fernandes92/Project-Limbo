using UnityEngine;
using System.Collections;

public class RopePlatformSystem : MonoBehaviour {

	private GameObject objectInside = null;

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player") {
				
			this.objectInside = col.collider.gameObject;
		}
	}

	void OnTriggerExit(Collider col){

		if(col.gameObject.tag == "Player") {

			this.objectInside = null;
		}
	}

	private void MoveWithPlatform(){

		Vector3 _position;


		if(this.objectInside != null){

			_position = this.objectInside.transform.position;
			_position.x = this.transform.position.x;
			_position.y = this.transform.position.y;
			this.objectInside.transform.position = _position;
		}

	}
}
