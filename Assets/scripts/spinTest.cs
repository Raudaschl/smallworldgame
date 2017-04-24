using UnityEngine;
using System.Collections;

public class spinTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		


		iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.5f,0.5f,0.5f), "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
