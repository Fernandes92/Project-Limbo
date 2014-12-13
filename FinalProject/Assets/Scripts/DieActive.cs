using UnityEngine;
using System.Collections;

public class DieActive : MonoBehaviour {


	public void ActiveDie(bool active){

		if (active) {
		
			gameObject.transform.collider.enabled = true;
		} else {
		
			gameObject.transform.collider.enabled = false;
		}
	}
}
