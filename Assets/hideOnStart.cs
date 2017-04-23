using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();
		rend.enabled = false;
	}

}
