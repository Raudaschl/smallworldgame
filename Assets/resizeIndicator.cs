using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class resizeIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void enabledButton(){
		gameObject.GetComponent<Image>().color = new Color32(72,255,0,130);
	}

	public void disabledButton(){
		gameObject.GetComponent<Image>().color = new Color32(255,0,0,130);
	}

}
