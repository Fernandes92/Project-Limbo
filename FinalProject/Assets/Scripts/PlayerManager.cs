using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	

	protected Vector3 checkPointPosition;
	public int checkPointNumber = 0;
	
	private Vector3 initialPosition;
	private string aniamtionName;
	
	protected bool isDead;
	protected bool arriveEnd = false;


	public bool isPlayerDead{

		get{

			return this.isDead;
		}
	}

	public int getcheckPoint{

		get{
			
			return this.checkPointNumber;
		}
	}

	public bool reachEnd{

		get{

			return this.arriveEnd;
		}
	}
	

	void OnTriggerEnter(Collider col){


		if (col.gameObject.tag == "Die") {
			
			StartCoroutine(this.Dead());
		}

		if(col.collider.gameObject.tag == "Bullet"){
			
			StartCoroutine(this.Dead());
		}

		if(col.gameObject.tag == "CheckPoint"){

			string _aux;
			_aux = col.gameObject.name.Substring(col.gameObject.name.Length - 1);
			this.checkPointPosition = collider.gameObject.transform.position;
			this.checkPointNumber = int.Parse(_aux);
		}

		if (col.gameObject.tag == "End") {
				
			arriveEnd = true;
		}

		/*
		if (col.gameObject.name == "Stair") {
			
			this.player.onStair = true;
		}*/

	}

	void OnTriggerExit(Collider col){

		/*
		if (col.gameObject.name == "Stair") {
			
			this.player.onStair = false;
			this.player.movement.y = 0;
		}*/
	}

	void OnCollisionEnter (Collision col){
				
		if(col.collider.gameObject.tag == "Bullet"){
		
			StartCoroutine(this.Dead());
		}


	}


	public IEnumerator Dead(){

		this.rigidbody.isKinematic = true;
		this.isDead = true;
		this.SetAnimation("Die");
		this.PlayAnimation();
		this.collider.enabled = false;
		yield return new WaitForSeconds(2);
				

	}

	public void RevivePlayer(){

		this.ReturntoCheckPoint ();
		this.collider.enabled = true;
		this.isDead = false;
		this.rigidbody.isKinematic =false;

	}

	/*
	 *Initialize player in the scene and set his position
	 */
	public void Initialize(Vector3 position){

		this.initialPosition = position;
		this.SetLocation (initialPosition);
	}

	/*
	 * Return player to tge check point area
	 */ 
	public void ReturntoCheckPoint(){

		this.SetLocation (checkPointPosition);
	}

	public void SetLocation(Vector3 newPosition){
		
		this.transform.position = newPosition;
	}
	
	protected void PlayAnimation(){
		
		this.animation.CrossFade (this.aniamtionName);
		this.animation.wrapMode = WrapMode.Once;
	}
	

	protected void SetAnimation(string animationName){
		
		this.aniamtionName = animationName;

	}


}
