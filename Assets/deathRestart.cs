using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathRestart : MonoBehaviour {

	private GameObject roomController;

	// Use this for initialization
	void Start () {
		// Use this for initialization
		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		roomController.GetComponent<level12Controller>().killPlayer = true;

	}


}
