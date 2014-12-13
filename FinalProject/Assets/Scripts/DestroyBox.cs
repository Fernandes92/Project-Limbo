using UnityEngine;
using System.Collections;

public class DestroyBox : MonoBehaviour {
	

	void OnTriggerEnter(Collider col){

		if (col.gameObject.name == "Box") {
				
			Destroy(col.gameObject);
		}

	}



}
