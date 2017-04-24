using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFade : MonoBehaviour {
	public Texture2D cameraTexture;
	// Use this for initialization
	void Start () {
		fadein ();
	}
	
	// Update is called once per frame
	public void fadein() {
		iTween.CameraFadeAdd(cameraTexture,200);
		iTween.CameraFadeFrom(1,0);
		iTween.CameraFadeTo(0,0.6f);
	}

	// Update is called once per frame
	public void fadeout() {
		iTween.CameraFadeAdd(cameraTexture,200);
		iTween.CameraFadeFrom(0,0);
		iTween.CameraFadeTo(1,5f);
	}
}
