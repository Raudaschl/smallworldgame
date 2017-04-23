using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companionCubeBlock : MonoBehaviour {

	private GameObject roomController;
	public GameObject collidingObject;
	public string variableName;


	void Start () {


		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}

	}

	void OnTriggerEnter (Collider col)
	{


		if (col.gameObject.name.ToString() == collidingObject.name.ToString()) {

			roomController.GetComponent<level12Controller> ().sceneVariable1 = variableName;

		}

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.name.ToString() == "Player") {

			roomController.GetComponent<level12Controller> ().sceneVariable1 = "";

		}


	}}
