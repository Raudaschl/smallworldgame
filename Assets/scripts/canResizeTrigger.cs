using UnityEngine;
using System.Collections;

public class canResizeTrigger : MonoBehaviour {
	public GameObject Player;

	private GameObject resizeIndicator;

	void Start () {
		Renderer rend = GetComponent<Renderer>();
		rend.enabled = false;

		resizeIndicator = GameObject.Find("resizeIndicator");

		if (Player == null) {

			Player = GameObject.FindGameObjectWithTag ("Player");

		}

	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name.ToString() == "Player") {
			
			Player.GetComponent<characterController> ().canResize = true;
			Debug.Log("Resize Active");
			resizeIndicator.GetComponent<resizeIndicator> ().enabledButton ();
		}

	}

	void OnTriggerExit (Collider col)
	{

		if (col.gameObject.name.ToString() == "Player") {
			Player.GetComponent<characterController> ().canResize = false;
			Debug.Log("Resize Deactivated");
			resizeIndicator.GetComponent<resizeIndicator> ().disabledButton ();

		}



	}
}
