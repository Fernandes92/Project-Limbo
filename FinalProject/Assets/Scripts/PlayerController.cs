using UnityEngine;
using System.Collections;

public class PlayerController : PlayerManager {

	//Classe Variables
	public float speed = 2.0f;
	public float stopingSpeed = 0.05f;
	public Vector3 jumpSpeed =  new Vector3(1.0f, 5.0f, 0f);
	public float pushPower = 1.5f;



	public Vector3 movement = Vector3.zero; //Vector3 with the moviment of the player (x, y, 0)
	private CharacterController controller;
	private float pastKeyDirection; //Last key pressed
	private float speedMultiplier; //Variable with the multipler of speed (RUN or WALK)
	private float idleTime = 10.0f;
	//public bool onStair = false;
	Vector3 climbingStairs = new Vector3 (0f, 0.5f, 0f);

	private const float WALK = 1.0f; 
	private const float RUN = 1.5f;
	private const int FORWARD = 1;
	private const int BACKWARD = -1;
	private const int IDLE = 0;
	private const float TIMEIDLE = 20f;

	//Direction of the player (FORWARD ,BACKWARD or IDLE)
	private int direction{
		
		get{
			if (0 < movement.x) {
				
				return FORWARD;
			} else if (movement.x < 0) {
				
				return BACKWARD;
			}
			
			return IDLE;
		}
	}
	//End Classe Variable



	//Classe Methods
	void Start () {

		controller = GetComponent<CharacterController> ();

	}
	

	void Update () {

		this.Action();	
	}
	

	void OnControllerColliderHit(ControllerColliderHit hit) {

		Rigidbody _body = hit.collider.attachedRigidbody;

								

		if(Input.GetButton ("Interact") && hit.collider.tag == "CanInteract"){

			if (_body == null || _body.isKinematic)
				return;
			
			if (hit.moveDirection.y < -0.3f)
				return;
			
			Vector3 pushDir = new Vector3(hit.moveDirection.x,0f,0f);

			_body.velocity = pushDir * pushPower;
		}


		if (Input.GetKey (KeyCode.UpArrow) && hit.collider.gameObject.name == "Stair") {
				
			this.Stair();
		}
	}



		//Private Classes
	/*
	 * Manage the current movement
	 * */
	private void Action(){

		this.pastKeyDirection = Input.GetAxis ("Horizontal");
		this.IdleTime ();

		if (!this.isDead) {
						
						if(movement.x == IDLE && idleTime > 0){

							this.SetAnimation ("Idle_01");
						}
						else if(movement.x == IDLE && idleTime <= 0) {

								this.SetAnimation ("Idle_02");

						}

						if (controller.isGrounded == true) {
			
								this.Move ();

								if (speedMultiplier == WALK && movement.x != IDLE) {

										this.SetAnimation ("Walk");
								} else if (speedMultiplier == RUN && movement.x != IDLE) {

										this.SetAnimation ("Run");
								}
						}
		
		
		
						if (controller.isGrounded == false) {
			
								this.Falling ();
						}
		
						//Jump with y aceleration
						if (Input.GetButtonDown("Jump") && controller.isGrounded == true && movement.x == IDLE) {
			
			
								this.Jump ();
								this.SetAnimation ("Jump");
						}

						//Jump with y and x aceleration
						if (Input.GetButtonDown("Jump") && controller.isGrounded == true && movement.x != IDLE) {
			
			
								this.MoveJump ();
								this.SetAnimation ("Jump");
						}
		
						
				} else {
					
						this.movement = Vector3.zero;
				}

		this.PlayAnimation ();

		controller.Move (movement * Time.deltaTime);
	}

	/*
	 * Set the moviment.x for the direction wanted or start to stop the player
	 * */
	private void Move(){



		if (Input.GetAxis ("Horizontal") == FORWARD ) {
			
			movement.x = this.getSpeedMultiplier() * speed;

			//Quaternion rotation = Quaternion.LookRotation(Vector3.right);
			//this.transform.rotation = rotation;

		} 
		else if(Input.GetAxis ("Horizontal") == BACKWARD ) {
			
			movement.x = -this.getSpeedMultiplier() * speed;

			//Quaternion rotation = Quaternion.LookRotation(Vector3.left);
			//this.transform.rotation = rotation;


		} 
		else{
			
			Stop();
		}

	}

	/*
	 * decrese the x Axis of the direction
	 * */
	private void Stop(){

		if(movement.x > 0){
			
			movement.x -= stopingSpeed;
		}else if(movement.x < 0){ 
			movement.x += stopingSpeed;
		}

		if (movement.x >= -0.2 && movement.x <= 0.2) {

			movement.x = 0;
		}

	}


	private void Falling(){

		movement.y += Physics.gravity.y * Time.deltaTime;
		
		if(Input.GetAxis ("Horizontal") == IDLE || Input.GetAxis ("Horizontal") != this.direction){
			
			movement.x = movement.x;
		}else if(Input.GetAxis ("Horizontal") != this.direction){

			this.Stop();
		}
	}


	private void Jump(){

		movement.y = jumpSpeed.y;
	}

	private void MoveJump(){

		movement.y = jumpSpeed.y;
		movement.x += this.direction * jumpSpeed.x;
	}


	private float getSpeedMultiplier(){
		

			
		if (Input.GetAxis ("Horizontal") == this.pastKeyDirection && controller.isGrounded == false) {

					return this.speedMultiplier;
			}
			
			if (Input.GetButton ("Run") && controller.isGrounded == true) {
				
					this.speedMultiplier = RUN;
					return this.speedMultiplier;
			} else {
				
					this.speedMultiplier = WALK;
					return this.speedMultiplier;
			}
			

	}
	
	private void Stair(){

		movement.y += this.climbingStairs.y;
	}

	private void IdleTime(){
		
		
		if (Input.anyKey) {
			
			this.idleTime = TIMEIDLE;
		} else {
			
			this.idleTime -= Time.deltaTime;
		}
		
		if (this.idleTime < -5) {
			
			this.idleTime = TIMEIDLE;
		}				
	}


	//Classe Methods
}
