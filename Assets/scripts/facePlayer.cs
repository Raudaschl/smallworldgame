﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour {

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (Player.transform);
	}
}
