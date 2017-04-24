using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneTriggerArea : MonoBehaviour {

	private GameObject roomController;
	public string triggerName;


	void Start () {


		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}

	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name.ToString() == "Player") {

			roomController.GetComponent<level12Controller> ().sceneTriggerName = triggerName;

		}

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.name.ToString() == "Player") {

			roomController.GetComponent<level12Controller> ().sceneTriggerName = "";

		}


	}
}
