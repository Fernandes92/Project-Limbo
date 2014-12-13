using UnityEngine;
using System.Collections;

public class RopeBoxTrap : MonoBehaviour {

	public Trigger trigger;
	public DieActive die;
	public GameObject endArea;

	// Use this for initialization
	void Start () {

		gameObject.rigidbody.isKinematic = true;
		gameObject.rigidbody.useGravity = false;
		//die = gameObject.GetComponent("DieActive") as DieActive;

		if(die != null){

			die.ActiveDie (true);
		}

	}

	void Update(){

		if (trigger.stateTrigger == true) {

			StartTrap();
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.name == endArea.name) {
				
			EndTrap();
		}
	}
	
	public void StartTrap(){

		gameObject.rigidbody.isKinematic = false;
		gameObject.rigidbody.useGravity = true;
	}

	public void EndTrap(){

		Destroy (gameObject.rigidbody.hingeJoint);
		gameObject.rigidbody.freezeRotation = true;
		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);

		if(die != null){
			
			die.ActiveDie (false);
		}
	}
}
