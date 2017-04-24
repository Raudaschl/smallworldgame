using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveBy (gameObject, iTween.Hash ("y", 0.2f, "easeType", "linear", "loopType", "pingPong"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
