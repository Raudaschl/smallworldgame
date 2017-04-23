using UnityEngine;
using System.Collections;

public class enviromentAudioVol : MonoBehaviour {

	private GameObject[] sfx;
	private GameObject[] music;

	private float[] minMusicVol, musicVol, maxMusicVol;
	private float[] minSfxVol, sfxVol, maxSfxVol;




	// Use this for initialization
	void Start () {
		sfx = GameObject.FindGameObjectsWithTag("sfx");
		music = GameObject.FindGameObjectsWithTag("music");



		getMinMaxVol (music);
		getMinMaxVol (sfx);






	}

	public void volumeControl(bool isSpeaking){


		volSpeaking (music, isSpeaking);
		volSpeaking (sfx, isSpeaking);

	}


	public void fadeAudioOut(){


		for (int i = 0; i < music.Length; i++) {

			GameObject audioObject = music[i];

			Hashtable musicOutHash = iTween.Hash(
				"volume", 0f,
				"pitch", 1f,
				"time", 0.8f,
				"oncomplete", "OnComplete",
				"oncompletetarget", this.gameObject,
				"oncompleteparams", audioObject
			);

			iTween.AudioTo(music[i], musicOutHash);
		}

		for (int i = 0; i < sfx.Length; i++) {

			GameObject audioObject = sfx[i];

			Hashtable sfxOutHash = iTween.Hash(
				"volume", 0f,
				"pitch", 1f,
				"time", 1f,
				"oncomplete", "OnComplete",
				"oncompletetarget", this.gameObject,
				"oncompleteparams", audioObject
			);

			iTween.AudioTo(sfx[i], sfxOutHash);
		}

		GameObject subtitleControl = GameObject.Find("Dialogue_Control");

		if (subtitleControl != null){


			Hashtable subOutHash = iTween.Hash(
				"volume", 0f,
				"pitch", 1f,
				"time", 0.8f,
				"oncomplete", "OnComplete",
				"oncompletetarget", this.gameObject,
				"oncompleteparams", subtitleControl
			);

			iTween.AudioTo(subtitleControl, subOutHash);

		}
	}


	public void fadeAudioIn(){

	}

	public void OnComplete(GameObject audioObject){
		Debug.Log(audioObject);
		audioObject.SetActive(false); 

	}



	private void getMinMaxVol (GameObject[] audioItems){

		if (audioItems == music) {
			minMusicVol = new float[audioItems.Length];
			musicVol = new float[audioItems.Length];
			maxMusicVol = new float[audioItems.Length];

			for (int i = 0; i < audioItems.Length; i++) {

				var audioItemSource = audioItems [i].GetComponent<AudioSource> ();
				//
				musicVol [i] = audioItemSource.volume;
				minMusicVol [i] = audioItemSource.volume - 0.2f;
				maxMusicVol [i] = audioItemSource.volume + 0.2f;
			}
		} else {
			minSfxVol = new float[audioItems.Length];
			sfxVol = new float[audioItems.Length];
			maxSfxVol = new float[audioItems.Length];

			for (int i = 0; i < audioItems.Length; i++) {

				var audioItemSource = audioItems [i].GetComponent<AudioSource> ();
				//
				minSfxVol[i] = audioItemSource.volume- 0.2f;
				sfxVol [i] = audioItemSource.volume;
				maxSfxVol[i] = audioItemSource.volume + 0.2f;
			}
		}

	}

	//Controls the audio item vol
	private void volSpeaking(GameObject[] audioItems, bool isSpeaking){

		if (audioItems == music) {

			if (isSpeaking == false) {

				for (int i = 0; i < audioItems.Length; i++) {
					var audioItem = audioItems [i];
					iTween.AudioTo (audioItem, maxMusicVol [i], 1, 1.2f);

				}

			} else {

				for (int i = 0; i < audioItems.Length; i++) {
					var audioItem = audioItems [i];

					iTween.AudioTo (audioItem, musicVol [i], 1, 1.2f);
				}

			}
		} else {
			if (isSpeaking == false) {

				for (int i = 0; i < audioItems.Length; i++) {
					var audioItem = audioItems [i];
					iTween.AudioTo (audioItem, maxSfxVol[i], 1, 1.2f);

				}

			} else {

				for (int i = 0; i < audioItems.Length; i++) {
					var audioItem = audioItems [i];

					iTween.AudioTo (audioItem, sfxVol[i], 1, 1.2f);
				}

			}

		}
	}


}
