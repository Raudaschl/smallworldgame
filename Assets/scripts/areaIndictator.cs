using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaIndictator : MonoBehaviour {

	private GameObject roomController;
	public string areaName;


	void Start () {


		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}

	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name.ToString() == "Player") {

			roomController.GetComponent<level12Controller> ().currentArea = areaName;

		}

	}
}
