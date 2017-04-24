using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Name{
	sceneVariable1,
	sceneVariable2,
	sceneVariable3
}


public class companionCubeBlock : MonoBehaviour {

	private GameObject roomController;
	public GameObject collidingObject;
	public Name variableName;
	public string variableString;


	void Start () {


		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}

	}

	void OnTriggerEnter (Collider col)
	{
		Debug.Log (col.gameObject.tag.ToString());
		Debug.Log (collidingObject.tag.ToString ());


		if (col.gameObject.tag.ToString() == collidingObject.tag.ToString()) {

			switch (variableName.ToString())
			{
			case "sceneVariable1":
				roomController.GetComponent<level12Controller> ().sceneVariable1 = variableString;
				break;
			case "sceneVariable2":
				roomController.GetComponent<level12Controller> ().sceneVariable2 = variableString;
				break;
			case "sceneVariable3":
				roomController.GetComponent<level12Controller> ().sceneVariable3 = variableString;
				break;
			default:

				break;
			}

		}

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag.ToString() == collidingObject.tag.ToString()) {

			switch (variableName.ToString())
			{
			case "sceneVariable1":
				roomController.GetComponent<level12Controller> ().sceneVariable1 = "";
				break;
			case "sceneVariable2":
				roomController.GetComponent<level12Controller> ().sceneVariable2 = "";
				break;
			case "sceneVariable3":
				roomController.GetComponent<level12Controller> ().sceneVariable3 = "";
				break;
			default:

				break;
			}

		}


	}}
