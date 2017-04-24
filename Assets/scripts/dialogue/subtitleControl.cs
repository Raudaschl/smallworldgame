using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class subtitleControl : MonoBehaviour {


	//	public string bubbleText;

	private TextAsset languageTextFile;

	private string langSelectXml;

	private GameObject subtitles;

	private float delayedSubtitleDisappear = 0.6f;

	private AudioSource audioSource;

	private string path;

	public string language = "english";

	private changeSubtitles changeSubtitles;
	private string textData;

	public int sceneNumber;
	private string sceneValueString;


	private bool toggleSubtitles = true;

	void Awake(){
		languageTextFile = Resources.Load ("english") as TextAsset;
	}

	void Start() {



		audioSource = GetComponent<AudioSource>();

		subtitles = GameObject.FindGameObjectWithTag ("subtitles");

//		Debug.Log (subtitles);
		changeSubtitles = subtitles.GetComponent<changeSubtitles> ();


		selectScene ();
		//Set Language

		languageSwitch (language);

		textData = languageTextFile.text;

	}

	void selectScene() {

		sceneValueString = gameObject.GetComponent<sceneArrayControl> ().determineScene (sceneNumber);
		print (sceneValueString);

	}


	//Set Language
	void languageSwitch(string language) {
		var prevLanguagetSelect = language.ToLower ();
		switch (prevLanguagetSelect) {
		case "english":
			langSelectXml = prevLanguagetSelect;
			break;
		case "french":
			langSelectXml = prevLanguagetSelect;

			break;
		default:
			Debug.Log ("Uh oh something is wrong with language select!");
			break;
		}

	}



	//dialogue - Parse the XMl document 
	private void ParseScript(string xmlData, int narrationNum) {
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load( new StringReader(xmlData) );

		string xmlPathPatternAudio = "//scene" + sceneNumber.ToString() + "/narration" + narrationNum.ToString() + "/audio";
		XmlNodeList myNodeListAudio = xmlDoc.SelectNodes(xmlPathPatternAudio );

		foreach (XmlNode node in myNodeListAudio) {


			AudioClip testAudio = Resources.Load (sceneValueString + "/audio/" + node.InnerText.ToString()) as AudioClip;

			audioSource.clip = testAudio;
			audioSource.Play ();
		}



		string xmlPathPattern = "//scene" + sceneNumber.ToString() + "/narration" + narrationNum.ToString() + "/lines/line";
		XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern );


		int i = 0;
		foreach (XmlNode node in myNodeList) {
			i++;
			int totalNodes = myNodeList.Count;

			float waitTime = float.Parse (node.SelectSingleNode ("timer").InnerText);
			string innerText = node.SelectSingleNode("textBub").InnerText;
			string triggerText = node.SelectSingleNode("trigger").InnerText;

			StartCoroutine(WaitAndPrint (waitTime, innerText, triggerText));

			//Remember to update the scenenArrayControl code you idiot
			if (totalNodes == i) {

				StartCoroutine(WaitAndPrint (audioSource.clip.length + delayedSubtitleDisappear, " ", triggerText));

			}

		}



	}

	private IEnumerator WaitAndPrint(float waitTime, string innerText, string triggerText) {

		yield return new WaitForSeconds(waitTime);

		BubbleRecordString (waitTime, innerText, triggerText);


	}


	//Loop Load lines from narration block
	private void BubbleRecordString (float waitTime, string innerText, string triggerText) {
		//		Debug.Log (waitTime);

		if (innerText != "") {
			Debug.Log (innerText);
			changeSubtitles.setText (0f, innerText);
		} else if (triggerText != "") {

			changeSubtitles.setTrigger(0f, triggerText);
		}

	}



	//Play dialogue lines with audio
	public void playDialogue(int value){

		if (value != 0){
			stopTheSubtitles ();
		}

		changeSubtitles.showSubtitles (value);


		toggleSubtitlesControl();


		ParseScript( textData, value );


	}


	public void stopTheSubtitles () {

		StopAllCoroutines ();
		audioSource.Stop ();
		changeSubtitles.hideSubtitles (false);

	}

	void toggleSubtitlesControl(){

		if (!toggleSubtitles) {
			changeSubtitles.hideText ();
		} else {
			changeSubtitles.showText ();
		}
	}


	void Update () {

		//Cancel Dialogue
		if (Input.GetKeyDown("/")){
			stopTheSubtitles ();
			//			print("Stopped " + Time.time);
		}

		//hide/show subtitles
		if (Input.GetKeyDown("h")){

			Debug.Log ("Subtitles off:" + toggleSubtitles);

			toggleSubtitles = !toggleSubtitles;

			toggleSubtitlesControl ();
		}

	}


}

