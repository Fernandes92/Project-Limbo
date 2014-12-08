using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject[] scenesPrefab;
	public PlayerController playerPrefab;
	public CameraPlayer cameraPrefab;
	public GUIBasic menu;
	public Camera cameraMenu, cameraEnd;

	private CameraPlayer cameraPlayer;
	private PlayerController playerController;
	private List<GameObject> listScene = new List<GameObject>();
	private bool canCheck = true;
	private DataBase db;

	// Use this for initialization
	void Start () {
	
		db = new DataBase ();
		db.DatabaseCheck ();

		menu.InitializeGUI (db.SelectlastScene());
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.playerController != null){

			if (this.playerController.isPlayerDead && canCheck) {
				
				StartCoroutine(this.ResetScene());
				
			}

			if(this.playerController.reachEnd){

				//cameraMenu.enabled = false;
				cameraPlayer.gameObject.SetActive(false);
				cameraEnd.gameObject.SetActive(true);
			}

			/*
			if (Input.GetKeyDown (KeyCode.Escape)) {
				
				if(menu.activeSelf){
					
					menu.SetActive(false);
				}else if(!menu.activeSelf){
					
					menu.SetActive(true);
				}
			}*/
		}

	}

	private IEnumerator ResetScene(){

		this.canCheck = false;
		yield return new WaitForSeconds(2);

		GameObject _newScene, oldScene;
		
		_newScene = Instantiate(this.scenesPrefab[this.playerController.getcheckPoint], this.scenesPrefab[this.playerController.getcheckPoint].transform.position, 
		                        this.scenesPrefab[this.playerController.getcheckPoint].transform.rotation) as GameObject;
		
		Destroy(listScene[this.playerController.getcheckPoint]);
		listScene.RemoveAt(this.playerController.getcheckPoint);
		
		_newScene.transform.name = "Scene" + this.playerController.getcheckPoint;
		
		listScene.Insert(this.playerController.getcheckPoint, _newScene);

		this.canCheck = true;
		this.playerController.RevivePlayer ();
	}

	public void Load(int scene){

		menu.gameObject.SetActive(false);

		for(int i = 0; i < scenesPrefab.Length; i++){
			
			GameObject _aux = Instantiate(this.scenesPrefab[i], this.scenesPrefab[i].transform.position, this.scenesPrefab[i].transform.rotation) as GameObject;
			
			_aux.transform.name = "Scene" + i;
			
			listScene.Insert(i, _aux);
		}
		
		GameObject _initialposition = GameObject.Find("Scene" + scene + "/CheckPoint" + scene);
		
		this.playerController = Instantiate (this.playerPrefab, _initialposition.transform.position, this.playerPrefab.transform.rotation) as PlayerController;
		playerController.transform.name = "Player";
		this.playerController.Initialize (_initialposition.transform.position);
		
		this.cameraPlayer = Instantiate (cameraPrefab ,Vector3.zero, this.cameraPrefab.transform.rotation) as CameraPlayer;
	}
}
