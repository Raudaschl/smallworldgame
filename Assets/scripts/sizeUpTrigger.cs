using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeUpTrigger : MonoBehaviour {

	private GameObject Player;


	void Start () {


		if (Player == null) {

			Player = GameObject.FindGameObjectWithTag ("Player");

		}

	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name.ToString() == "Player") {
			
			Player.GetComponent<characterController> ().cannotResizefunction ();

			if (Player.GetComponent<characterController> ().tinyMode == true) {
				Player.GetComponent<characterController> ().scaleUp ();
			}


		}

	}

	void OnTriggerExit (Collider col)
	{
		if (Player.GetComponent<characterController> ().resizeArea == true) {

			Player.GetComponent<characterController> ().canResizeFunction ();

		}


	}

}
