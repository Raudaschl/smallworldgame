using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSubtitles : MonoBehaviour {

	private GameObject subtitlesBackdrop;
	private GameObject subtitleCharacter;
	private Text uiLabel;
	private enviromentAudioVol controlEnviromentVol;
	private bool firstSceneSpeech;
	private IEnumerator coroutine;

	public int currentdialoguenum;

	public GameObject eventController;
	private bool speaking;


	// Use this for initialization
	void Start () {
		firstSceneSpeech = false;

		uiLabel = GetComponent<Text> ();

		subtitlesBackdrop = GameObject.FindGameObjectWithTag ("subtitle-backdrop");
		subtitleCharacter = GameObject.FindGameObjectWithTag ("subtitleCharacter");
		eventController = GameObject.FindGameObjectWithTag ("sceneController");

		hideSubtitles (true);

		controlEnviromentVol = gameObject.GetComponent<enviromentAudioVol> ();

	}



	public void setText(float waitTime, string subtitle){

		coroutine = WaitAndPrint (waitTime, subtitle);
		StartCoroutine(coroutine);

	}

	public void setTrigger(float waitTime, string triggerText){

		if (eventController != null) {
			Debug.Log (triggerText);
			eventController.BroadcastMessage ("dialogueCompleteTrigger", triggerText);
			StartCoroutine (coroutine);
		}

	}

	private IEnumerator WaitAndPrint(float waitTime, string subtitle) {


		yield return new WaitForSeconds(waitTime);

		uiLabel.text = subtitle;

		if (uiLabel.text == " ") {

			hideSubtitles(false);

		}
	}

	private void finishedSpeaking(){
		Debug.Log ("finished speaking");

		controlEnviromentVol.volumeControl (false);

		speaking = false;
	}

	private void startedSpeaking(){
		Debug.Log ("started speaking");
		controlEnviromentVol.volumeControl (true);
		speaking = true;
	}


	//Controls subtitle visibility

	public void showSubtitles(int currentdialoguenumSent){
		showSubtitleBackdrop();
		uiLabel.text = "";
		//		Debug.Log (firstSceneSpeech);

		startedSpeaking ();


		currentdialoguenum = currentdialoguenumSent;
	}

	public void hideSubtitles(bool start){


		hideSubtitleBackdrop ();
		hideText ();

		//Broadcast that dialogue has ended
		if (!start) {
			if (eventController != null) {
				eventController.BroadcastMessage ("dialogueCompleteTrigger", currentdialoguenum.ToString());
				finishedSpeaking ();
			}

		}
	}


	public bool isSpeaking(){
		if (speaking == true){
			return true;
		} else {
			return false;
		}
	}


	private void showSubtitleBackdrop(){
		subtitlesBackdrop.GetComponent<Image>().enabled = true;
		subBgAnimateIn();

		if (subtitleCharacter != null){
			subCharacterAnimateIn();
		}

	}

	private void hideSubtitleBackdrop(){
		subBgAnimateOut();

		if (subtitleCharacter != null){
			subCharacterAnimateOut();
		}


	}

	public void showSubtitleTextAndBackdrop(){

		if (speaking == true){
			subBgAnimateIn();
			showText();
		}



	}

	public void hideSubtitleTextAndBackdrop(){

		if (speaking == true){
			subBgAnimateOut();
			hideText();
		}



	}


	private void subBgAnimateIn(){
		Vector3 test = new Vector3(1f,1f,1f);

		iTween.ScaleTo(subtitlesBackdrop, iTween.Hash(
			"scale"    , test,
			"time"    , 0.3f,
			"easeType", iTween.EaseType.easeInOutQuint
		));
	}

	private void subCharacterAnimateIn(){
		Vector3 test = new Vector3(1,1,1);

		iTween.ScaleTo(subtitleCharacter, iTween.Hash(
			"scale"    , test,
			"time"    , 1,
			"easeType", iTween.EaseType.easeInOutQuint
		));
	}

	private void subBgAnimateOut(){
		Vector3 test = new Vector3(0,0,0);

		iTween.ScaleTo(subtitlesBackdrop, iTween.Hash(
			"scale"    , test,
			"time"    , 0.3f
		));
	}

	private void subCharacterAnimateOut(){
		Vector3 test = new Vector3(0,0,0);
		iTween.ScaleTo(subtitleCharacter, iTween.Hash(
			"scale"    , test,
			"time"    , 0.5f
		));
	}

	public void hideText(){
		Color c = uiLabel.color;
		c.a = 0;
		uiLabel.color = c;
	}

	public void showText(){
		Color c = uiLabel.color;
		c.a = 1;
		uiLabel.color = c;
	}
		


}
