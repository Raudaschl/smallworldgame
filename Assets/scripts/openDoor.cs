using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {

	public bool triggerBool;

	
	public void trigger(){
		if (triggerBool == false) {
			iTween.MoveBy (gameObject, iTween.Hash ("x", 3, "easeType", "easeInOutExpo", "delay", .1));
			triggerBool = true;
		} else {
			iTween.MoveBy(gameObject, iTween.Hash("x", -3, "easeType", "easeInOutExpo", "delay", .1));

			triggerBool = false;
		}

	}

}
