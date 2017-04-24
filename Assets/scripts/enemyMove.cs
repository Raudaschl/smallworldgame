using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyMove : MonoBehaviour {
	public float deathDistance = 0.5f;
	public float distanceAway;
	public Transform target;
	public Transform spawnPointTransform;
	public AudioClip mouseSfx;

	private AudioSource audio;
	private NavMeshAgent navComponent;
	private GameObject roomController;
	private characterController characterController;
	private bool runAway;
	private float dist;
	private float returnDist;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		characterController = target.GetComponent<characterController> ();
		navComponent = this.gameObject.GetComponent<NavMeshAgent> ();

		if (roomController == null) {

			roomController = GameObject.FindGameObjectWithTag ("sceneController");

		}

		audio = GetComponent<AudioSource>();
		audio.clip = mouseSfx;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		if (target) {
			if (characterController.tinyMode == true) {
				dist = Vector3.Distance (target.position, transform.position);

				runAway = false;
				navComponent.SetDestination (target.position);
			} else {
				returnDist = Vector3.Distance (spawnPointTransform.position, transform.position);

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

		if (runAway) {
			if (returnDist <= deathDistance) {
				//			Kill player
				Destroy(gameObject);

				roomController.GetComponent<level12Controller> ().enemyCreated = false;
			}
		}

	}


}
