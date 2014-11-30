using UnityEngine;
using System.Collections;

public class TeleportPad : MonoBehaviour {

	public TeleportPad tp;
	private GameObject box;

	void OnTriggerStay(Collider collider){
		
		if (collider.gameObject.tag == "Player") {
			
			if(Input.GetKeyDown(KeyCode.E)){

				Vector3 _newPosition = tp.transform.position;



				if(this.box != null){

					this.box.transform.position = _newPosition;
					collider.gameObject.transform.position  = _newPosition + new Vector3(0f, 2f, 0f);
				}else{

					//_newPosition.y += 1;
					collider.gameObject.transform.position  = _newPosition;
				}
					
			
			}
			
			
		}
	}

	void OnTriggerEnter(Collider collider){

		if (collider.gameObject.name == "Box") {

			this.box = collider.gameObject;
		}
	}
}
