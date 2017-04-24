using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyMove : MonoBehaviour {
	public float deathDistance = 0.5f;
	public float distanceAway;
	public Transform target;
	public Transform spawnPointTransform;

	private NavMeshAgent navComponent;
	private GameObject roomController;
	private characterController characterController;
	private bool runAway;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		characterController = target.GetComponent<characterController> ();
		navComponent = this.gameObject.GetComponent<NavMeshAgent> ();

		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (target.position, transform.position);

		if (target) {
			if (characterController.tinyMode == true) {
				runAway = false;
				navComponent.SetDestination (target.position);
			} else {
				runAway = true;
				navComponent.SetDestination (spawnPointTransform.position);
			}

		}

		if (dist <= deathDistance) {
//			Kill player
			if (characterController.tinyMode == true){
				roomController.GetComponent<level12Controller>().killPlayer = true;
			}


		}
	}


}
