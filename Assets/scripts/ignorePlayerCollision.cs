using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorePlayerCollision : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			Physics.IgnoreCollision (collision.gameObject.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
		}

		if (collision.gameObject.tag == "pickupObject") {
			Physics.IgnoreCollision (collision.gameObject.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
		}

		if (collision.gameObject.tag == "enemy") {
			Physics.IgnoreCollision (collision.gameObject.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
		}
	}
}
