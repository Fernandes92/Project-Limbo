using UnityEngine;
using System.Collections;

public class TriggerTrap : MonoBehaviour {
	

	void OnTriggerEnter(Collider col){

		if (col.gameObject.name == "Box") {
				
			Destroy(col.gameObject);
		}

	}



}
