using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject gunBarrel;
	public Bullet bulletPrefab;
	public GameObject temperature;
	public Material[] temperatureColors;
	public AudioClip[] audioclip;
	public Vector3 bulletSpeed;
	public Quaternion bulletRotation;


	public float FIRETIME = 0.2f; // Time to the next shoot
	public float STARTFIRING = 2.0f; 
	public float OVERHEATINGTIME = 5.0f;
	public float COOLINGTIME = 3.0f;
	public float movementSpeed = 2.0f;
	public Vector3 gunMovementDistance = Vector3.zero;
	public int gunLife = 10;

	private float shootFrequenci = 0f;
	private float timeStartFiring = 0f;
	private float timeOverHeat = 0f;
	private float timeCooling = 0f;
	private DrawLine lazerSight;
	private bool hitPlayer = false;
	private bool gunOverHeat = false;
	private bool gunCool = true;
	private Vector3 initialPosition;
	private Vector3 endPosition;
	private Vector3 direction = Vector3.zero;
	private ParticleSystem smoke;
	private bool isDamage = false;

	private Vector3 getDirection{

		get{

			if((this.endPosition.x - this.initialPosition.x) > 0){

				if(this.transform.position.x <= this.initialPosition.x){

					this.direction = Vector3.right;
					return this.direction;
				}else if(this.transform.position.x >= this.endPosition.x){

					this.direction = Vector3.left;
					return this.direction;
				}else{

					return this.direction;
				}
			}else{

				if(this.transform.position.x >= this.initialPosition.x){
					
					this.direction = Vector3.left;
					return this.direction;
				}else if(this.transform.position.x <= this.endPosition.x){
					
					this.direction = Vector3.right;
					return this.direction;
				}else{
					
					return this.direction;
				}
			}

		}
	}

	private bool isGunOverHeat{


		get{

			if(this.timeOverHeat <= 0){

				this.gunOverHeat = false;
				return this.gunOverHeat;
			}else if(this.timeOverHeat > OVERHEATINGTIME){

				this.gunOverHeat = true;
				return this.gunOverHeat;
			}else{

				return this.gunOverHeat;
			}
			
		}

		set{

		}

	}


	private bool isGunCool{

		get{

			if(this.timeCooling > 0){

				return false;
			}else{

				return true;
			}
		}

		set{
			
		}
	}




	// Use this for initialization
	void Start () {
	
		this.lazerSight = this.gameObject.GetComponentInChildren<DrawLine> ();
		this.initialPosition = this.transform.position;
		this.endPosition = this.transform.position + this.gunMovementDistance;
		this.smoke = this.GetComponentInChildren<ParticleSystem> ();

		if(this.smoke != null)
			this.smoke.enableEmission = false;

		if(this.temperature != null)
			this.temperature.renderer.material = this.temperatureColors[0];
	}
	
	// Update is called once per frame
	void Update () {

		if (!this.isDamage) {

			this.GunFire ();
			this.Movement ();
		}
	}

	void OnCollisionEnter (Collision col){
		
		if(col.gameObject.tag == "Bullet"){

			this.DamageGun();
		}
	}

	private void GunFire(){

		if(!this.isGunOverHeat){
			
			if(this.hitPlayer == false){

				if(this.temperature != null)
					this.temperature.renderer.material = this.temperatureColors[0];

				this.timeStartFiring = 0f;
				this.lazerSight.EnableDrawLine();
				this.CheckForPlayer();
			}else{
				if(this.temperature != null)
					this.temperature.renderer.material = this.temperatureColors[1];

				this.lazerSight.DisableDrawLine();
				this.Fire();


				
			}
		}else{

			if(this.temperature != null)
				this.temperature.renderer.material = this.temperatureColors[2];

			this.CoolingGun();
			this.hitPlayer = false;
		}
	}

	private void CheckForPlayer(){

		RaycastHit _hit;

		if(Physics.Raycast(lazerSight.transform.position, lazerSight.rayCastDist, out _hit)){

			if(_hit.collider.tag == "Player"){

				this.hitPlayer = true;
			}else{

				this.hitPlayer = false;
			}
		}else{

			this.hitPlayer = false;
		}
	}

	private void Fire(){

		if(this.timeStartFiring >= STARTFIRING ){
			
			if (this.shootFrequenci > 0) {
				this.shootFrequenci -= Time.deltaTime;
				  
			} else {


				Bullet _newBullet = Instantiate(bulletPrefab, gunBarrel.transform.position, gunBarrel.transform.rotation) as Bullet;
				
				_newBullet.rigidbody.velocity = transform.TransformDirection(bulletSpeed);
				_newBullet.transform.rotation = this.bulletRotation;

				this.audio.clip = this.audioclip[0];
				this.audio.Play();

				this.shootFrequenci = FIRETIME;

			}

			this.OverHeatingGun(); // Da certo
		}else{
			
			this.timeStartFiring += Time.deltaTime;
		}


	}

	private void OverHeatingGun(){


		timeOverHeat += Time.deltaTime;


		if (this.isGunOverHeat) {
				
			this.timeCooling = COOLINGTIME;
		}

	}

	private void CoolingGun(){


		timeCooling -= Time.deltaTime;

		if (this.isGunCool) {
				
			this.timeOverHeat = 0;
		}

	}

	private void Movement(){

		float _speed = this.movementSpeed * Time.deltaTime;

		if(this.initialPosition != this.endPosition)
			this.transform.position += this.getDirection *_speed;

		/*
		if (this.transform.localPosition.x  < this.endPosition.x) {
		

			//Vector3.MoveTowards(this.transform.position, this.endPosition, _speed);

		}else if(this.transform.localPosition.x > this.endPosition.x){

			//Vector3.MoveTowards(this.transform.position, this.initialPosition, speed);
		}
*/
	}

	private void DamageGun(){

		this.gunLife -= 1;

		if (this.gunLife <= 0) {
			this.isDamage = true;

			if(this.temperature != null)
				this.temperature.renderer.material = this.temperatureColors[3];

			this.lazerSight.DisableDrawLine();
		}

		if (this.gunLife <= 5) {
		
			if(this.smoke != null)
				this.smoke.enableEmission = true;

		}
	}
	
}
