using UnityEngine;
using System.Collections;

public class spinTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));


		iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.1f,0.1f,0.1f), "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
