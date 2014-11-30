using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject[] scenesPrefab;
	public PlayerController playerPrefab;

	private PlayerController playerController;
	private List<GameObject> listScene = new List<GameObject>();
	private bool canCheck = true;

	// Use this for initialization
	void Start () {
	
		this.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.playerController.isPlayerDead && canCheck) {

			StartCoroutine(this.ResetScene());

		}
	}


	private void Initialize(){

		for(int i = 0; i < scenesPrefab.Length; i++){

			GameObject _aux = Instantiate(this.scenesPrefab[i], this.scenesPrefab[i].transform.position, this.scenesPrefab[i].transform.rotation) as GameObject;

			_aux.transform.name = "Scene" + i;

			listScene.Insert(i, _aux);
		}

		GameObject _initialposition = GameObject.Find("Scene0/CheckPoint0");

		this.playerController = Instantiate (this.playerPrefab, _initialposition.transform.position, this.playerPrefab.transform.rotation) as PlayerController;

		this.playerController.Initialize (_initialposition.transform.position);
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
}
