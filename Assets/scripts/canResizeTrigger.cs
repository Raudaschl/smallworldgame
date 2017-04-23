using UnityEngine;
using System.Collections;

public class canResizeTrigger : MonoBehaviour {
	private GameObject Player;


	void Start () {
		

		if (Player == null) {

			Player = GameObject.FindGameObjectWithTag ("Player");

		}

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name.ToString() == "Player") {

			Player.GetComponent<characterController> ().canResizeFunction ();
			Player.GetComponent<characterController> ().resizeArea = true;
		}


	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.name.ToString() == "Player") {

			Player.GetComponent<characterController> ().cannotResizefunction ();
			Player.GetComponent<characterController> ().resizeArea = false;
		}


	}
		
}
