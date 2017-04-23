using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Type{
	door
}

public class triggerObjectSelect : MonoBehaviour {
	public GameObject triggerObject;
	public Type objectType;

	// Use this for initialization
	public void startTrigger(){

		string objectTypeString = objectType.ToString ();

		switch (objectTypeString)
		{
		case "door":
			triggerObject.GetComponent<openDoor> ().trigger ();
			break;
		default:

			break;
		}

	

	}
}
