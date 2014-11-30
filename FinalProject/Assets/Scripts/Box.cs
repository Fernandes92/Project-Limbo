using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour{

	private Rigidbody body;
	private FixedJoint fixedJoint;
	private Vector3 positionInitial;

	// Use this for initialization
	void Start () {
	
		this.body = this.gameObject.GetComponent<Rigidbody>();
		this.fixedJoint = this.gameObject.GetComponent<FixedJoint> ();

		this.positionInitial = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit(Collision col){

		if(col.collider.tag == "Player")
			this.body.velocity = Vector3.zero;
	}


	void OnJointBreak(float breakForce){

		this.fixedJoint.connectedBody = null;
		this.gameObject.tag = "CanInteract";
	}


}
