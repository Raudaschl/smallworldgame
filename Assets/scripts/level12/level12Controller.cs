using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level12Controller : MonoBehaviour {
	AudioSource dialogueControl;

	//Dialogue Setup
	public GameObject DialogueControl;
	public string currentArea;
	public string sceneTriggerName;
	public string sceneVariable1, sceneVariable2, sceneVariable3;
	public GameObject enemy;
	public GameObject enemypos1, enemypos2, enemypos3;
	public bool scene1, jumpRoom, scene2, scene3, scene4, scene5;
	public bool killPlayer;
	public int deaths;

	private GameObject Player;
	public bool enemyCreated;

	private GameObject lastCube;
	private GameObject mainCamera;

	private subtitleControl playAudio;
	private string currentDialogueNumCompleted;
	int audiocomplete = 0;


	// Use this for initialization
	void Start () {
//		StartCoroutine (StartScene ());


		//Dialogue Setup
		currentDialogueNumCompleted = "";
		DialogueControl = GameObject.FindGameObjectWithTag ("subtitleControl");
		playAudio = DialogueControl.GetComponent<subtitleControl> ();

		Player = GameObject.FindGameObjectWithTag ("Player");

		mainCamera = GameObject.Find ("Camera");
		lastCube = GameObject.Find ("lastView");
	}

	//Accepts a broadcast from change subtitles when dialogue lines complete
	public void dialogueCompleteTrigger(string currentdialoguenum) {
		currentDialogueNumCompleted = currentdialoguenum;
	}

	// Update is called once per frame
	void Update () {


////		Scene5 test
//		if (scene5 == false) {
//			StartCoroutine (Scene5Start ());
//		}
//
//


		//
		//		//Dynamic stop triggers
				if (currentDialogueNumCompleted == "4") {
					//Play dialogue audioclip
		
					Debug.Log ("trigger");
					audiocomplete=4;
//					StartCoroutine (partTwo ());
					currentDialogueNumCompleted = "";
				}
		//		else if (currentDialogueNumCompleted == "1" && audiocomplete == 1) {
		//			//Play dialogue audioclip
		//
		//			Debug.Log ("endclot");
		//			audiocomplete++;
		//
		//			currentDialogueNumCompleted = "";
		//		}
		//		else if (currentDialogueNumCompleted == "2" && audiocomplete == 2) {
		//			//Play dialogue audioclip
		//
		//			Debug.Log ("endclot2");
		//			audiocomplete++;
		//
		//			currentDialogueNumCompleted = "";
		//		}
		//		else if (currentDialogueNumCompleted == "3" && audiocomplete == 3) {
		//			//Play dialogue audioclip
		//
		//			Debug.Log ("endclot3");
		//			audiocomplete++;
		//
		//			currentDialogueNumCompleted = "";
		//		}




		//StartScene Conditions

		if (currentArea == "room1") {
				if (Player.GetComponent<characterController>().tinyMode == true){
					
					if (scene1 == false) {
						StartCoroutine (StartScene ());
					}
		
				}
		}

		if (currentArea == "JumpRoom") {
			if (Player.GetComponent<characterController>().tinyMode == true){

				if (jumpRoom == false) {
					StartCoroutine (JumpRoom ());
				}

			}
		}


		if (currentArea == "room2") {

			if (scene2 == false) {
				StartCoroutine (Scene2Start ());
			}


			if (sceneTriggerName == "mouse1") {
				if (Player.GetComponent<characterController>().tinyMode == true){

					if (sceneVariable1 != "true") {

						if (!enemyCreated) {
							GameObject enemyTemp = Instantiate (enemy, enemypos1.transform.position, enemypos1.transform.rotation) as GameObject;
							enemyTemp.GetComponent<enemyMove> ().spawnPointTransform = enemypos1.transform;
							enemyCreated = true;
						}

					}

				}
			}
		}

		if (currentArea == "room3") {

			if (scene3 == false) {
				StartCoroutine (Scene3Start ());
			}

			if (sceneTriggerName == "mouse23") {
				if (Player.GetComponent<characterController>().tinyMode == true){


					if (!enemyCreated) {

						if (sceneVariable1 != "true") {
							GameObject enemyTemp = Instantiate (enemy, enemypos2.transform.position, enemypos2.transform.rotation) as GameObject;
							enemyTemp.GetComponent<enemyMove> ().spawnPointTransform = enemypos2.transform;
						}

						if (sceneVariable2 != "true") {
							GameObject enemyTemp = Instantiate (enemy, enemypos3.transform.position, enemypos3.transform.rotation) as GameObject;
							enemyTemp.GetComponent<enemyMove> ().spawnPointTransform = enemypos3.transform;
						}


						enemyCreated = true;
					}
						

				}
			}
		}

		if (currentArea == "room4") {


			if (Player.GetComponent<characterController>().tinyMode == true){

				if (scene4 == false) {
					StartCoroutine (Scene4Start ());
				}

			}

				
		}

		if (currentArea == "room5") {


			if (scene5 == false) {
				StartCoroutine (Scene5Start ());
			}



		}

		if (killPlayer == true) {
			resetPlayer ();
			killPlayer = false;
		}

	}
		

	IEnumerator StartScene(){

		Debug.Log("startscene");
		scene1 = true;

		emptySceneVariables ();
		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);

		//===== Narrative Start Here ======//

		playAudio.playDialogue (0);

//		yield return new WaitForSeconds (2);
//		yield return new WaitUntil (() => audiocomplete == 1);
//
//		playAudio.playDialogue (1);
//
	}


	IEnumerator JumpRoom(){

		Debug.Log("JumpRoom");
		jumpRoom = true;

		emptySceneVariables ();
		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);

		playAudio.playDialogue (1);

		//===== Narrative Start Here ======//

		//		playAudio.playDialogue (0);

		//		yield return new WaitForSeconds (2);
		//		yield return new WaitUntil (() => audiocomplete == 1);
		//
		//		playAudio.playDialogue (1);
		//
	}


	IEnumerator Scene2Start(){

		Debug.Log("scene2");
		scene2 = true;

		emptySceneVariables ();
		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);

		playAudio.playDialogue (1);

		//===== Narrative Start Here ======//

//		playAudio.playDialogue (0);

		//		yield return new WaitForSeconds (2);
		//		yield return new WaitUntil (() => audiocomplete == 1);
		//
		//		playAudio.playDialogue (1);
		//
	}

	IEnumerator Scene3Start(){

		Debug.Log("scene3");
		scene3 = true;

		emptySceneVariables ();
		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);
		playAudio.playDialogue (2);

		//===== Narrative Start Here ======//

		//		playAudio.playDialogue (0);

		//		yield return new WaitForSeconds (2);
		//		yield return new WaitUntil (() => audiocomplete == 1);
		//
		//		playAudio.playDialogue (1);
		//
	}

	IEnumerator Scene4Start(){

		Debug.Log("scene4");
		scene4 = true;

		emptySceneVariables ();
		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);
		playAudio.playDialogue (3);

		//===== Narrative Start Here ======//

		//		playAudio.playDialogue (0);

		//		yield return new WaitForSeconds (2);
		//		yield return new WaitUntil (() => audiocomplete == 1);
		//
		//		playAudio.playDialogue (1);
		//
	}

	IEnumerator Scene5Start(){

		Debug.Log("scene5");
		scene5 = true;

		mainCamera.GetComponent<camMouseLook> ().enabled = false;

//		emptySceneVariables ();
//		resetDeathsInt ();

		yield return new WaitForSeconds (0.1f);
		playAudio.playDialogue (4);

		//		mainCamera.transform.position = lastCube.transform.position;
		//		mainCamera.transform.localEulerAngles = lastCube.transform.localEulerAngles;

		iTween.RotateTo (mainCamera, lastCube.transform.localEulerAngles, 20);
		iTween.MoveTo (mainCamera, lastCube.transform.localPosition, 30);

//		iTween.MoveTo(mainCamera, iTween.Hash ("path", lastCube.transform.localPosition, "easeType", "easeInOutExpo", "time", 30));

		yield return new WaitForSeconds (7f);
		mainCamera.GetComponent<cameraFade> ().fadeout ();

		//===== Narrative Start Here ======//

		yield return new WaitUntil (() => audiocomplete == 4);

		yield return new WaitForSeconds (1f);
		Debug.Log ("end of game");

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(0);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

	void emptySceneVariables(){
		sceneVariable1 = "";
		sceneVariable2 = "";
		sceneVariable3 = "";
	}

	void resetDeathsInt(){
		deaths = 0;
	}

	public void resetPlayer(){

		Debug.Log ("kill player");



		Camera.main.GetComponent<cameraFade> ().fadein ();

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		foreach (GameObject enemy in enemies)
			GameObject.Destroy (enemy);

		enemyCreated = false;

		Player.GetComponent<characterController> ().scaleUp ();

		switch (currentArea)
		{
		case "room1":
			
			break;
		case "room2":
			Player.transform.position = GameObject.Find ("respawn2").transform.position;



			break;
		case "room3":
			Player.transform.position = GameObject.Find ("respawn3").transform.position;
			break;
		default:

			break;
		}
	}

}
