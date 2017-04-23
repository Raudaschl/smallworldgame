using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testroomController : MonoBehaviour {
	AudioSource dialogueControl;

	//Dialogue Setup
	public GameObject DialogueControl;
	private subtitleControl playAudio;
	private string currentDialogueNumCompleted;
	int audiocomplete = 0;


	// Use this for initialization
	void Start () {
		StartCoroutine (StartScene ());

		//Dialogue Setup
		currentDialogueNumCompleted = "";
		DialogueControl = GameObject.FindGameObjectWithTag ("subtitleControl");
		playAudio = DialogueControl.GetComponent<subtitleControl> ();
		
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
	}
		

	IEnumerator StartScene(){

		Debug.Log("startscene");

		yield return new WaitForSeconds (0.5f);
		//SFX_Abacus_Vocalisation_Delighted.Play ();



		//Pump pop-in
		yield return new WaitForSeconds (1.5f);

		//===== Narrative Start Here ======//

		playAudio.playDialogue (1);

		//yield return new WaitForSeconds (2);
		yield return new WaitUntil (() => audiocomplete == 1);

		playAudio.playDialogue (1);

	}
	

}
