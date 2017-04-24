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
	public GameObject enemy1, enemy2, enemy3;
	public bool scene1, scene2, scene3, scene4;

	private GameObject Player;
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
		
	}

	//Accepts a broadcast from change subtitles when dialogue lines complete
	public void dialogueCompleteTrigger(string currentdialoguenum) {
		currentDialogueNumCompleted = currentdialoguenum;
	}

	// Update is called once per frame
	void Update () {



		//
		//		//Dynamic stop triggers
				if (currentDialogueNumCompleted == "0" && audiocomplete == 0) {
					//Play dialogue audioclip
		
					Debug.Log ("trigger");
					audiocomplete++;
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


		if (currentArea == "room2") {
			if (sceneTriggerName == "mouse1") {
				if (Player.GetComponent<characterController>().tinyMode == true){

					if (sceneVariable1 != "true") {
						enemy1.SetActive(true);
					}

				}
			}
		}

		if (currentArea == "room3") {
			if (sceneTriggerName == "mouse23") {
				if (Player.GetComponent<characterController>().tinyMode == true){

					if (sceneVariable1 != "true") {
						enemy2.SetActive(true);

					}

					if (sceneVariable2 != "true"){
						enemy3.SetActive(true);
					}

				}
			}
		}
	}
		

	IEnumerator StartScene(){

		Debug.Log("startscene");
		scene1 = true;

		yield return new WaitForSeconds (0.1f);

		//===== Narrative Start Here ======//

		playAudio.playDialogue (0);

//		yield return new WaitForSeconds (2);
//		yield return new WaitUntil (() => audiocomplete == 1);
//
//		playAudio.playDialogue (1);
//
	}
	

}
