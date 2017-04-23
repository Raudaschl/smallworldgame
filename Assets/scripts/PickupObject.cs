using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	public GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float bigDistance = 4f;
	public float smallDistance = 0.6f;

	public float smooth;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		distance = bigDistance;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
		Debug.DrawRay(transform.position, forward, Color.green);


		if(carrying) {
			carry(carriedObject);
			checkDrop();
			//rotateObject();
		} else {
			pickup();
		}
	}

	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}

	void carry(GameObject o) {


		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup() {
		if(Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, distance)) {
				Pickupable p = null;

				Debug.Log (hit.collider);

				if (hit.collider.GetComponent<Pickupable> () != null) {

					p = hit.collider.GetComponent<Pickupable> ();



				} else if (hit.collider.GetComponent<triggerObjectSelect> () != null){

					hit.collider.GetComponent<triggerObjectSelect> ().startTrigger();
				}
					

				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					//p.gameObject.rigidbody.isKinematic = true;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop() {
		if(Input.GetKeyDown (KeyCode.E)) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		//carriedObject.gameObject.rigidbody.isKinematic = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
}
