using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public GameObject camera;
	public float fieldOfView = 60;
	public float speed = 10.0f;
	public float forceConst = 5;
	public bool tinyMode = false;
	public bool canResize = false;




	private bool canJump;
	private Rigidbody selfRigidbody;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		selfRigidbody = GetComponent<Rigidbody>();


	}


	void FixedUpdate(){
		if(canJump){
			canJump = false;
			selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
		}
	}


	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		transform.Translate (straffe, 0, translation);

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetMouseButtonDown(0)) {
			switchSize ();
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			canJump = true;
		}
	
	}

	void switchSize() {

		fieldOfView = camera.GetComponent<Camera> ().fieldOfView;

		if (canResize == true) {



			if (tinyMode == false) {
				scaleUp ();
			} else {

				scaleDown ();
			}
		}

	}

	public void scaleUp(){
		iTween.ScaleTo (gameObject, iTween.Hash ("scale", new Vector3 (0.05f, 0.05f, 0.05f), "easeType", "easeInOutExpo"));
		gameObject.GetComponent<Rigidbody> ().mass = 0.2f;

		iTween.ValueTo (gameObject, iTween.Hash ("from", fieldOfView, "to", 80, "easeType", "easeInOutExpo", "onUpdate", "UpdateFOVDisplay"));

		forceConst = 0.5f;

		tinyMode = true;
	}

	public void scaleDown(){
		iTween.ScaleTo (gameObject, iTween.Hash ("scale", new Vector3 (1f, 1f, 1f), "easeType", "easeInOutExpo"));
		gameObject.GetComponent<Rigidbody> ().mass = 1f;

		iTween.ValueTo (gameObject, iTween.Hash ("from", fieldOfView, "to", 60, "easeType", "easeInOutExpo", "onUpdate", "UpdateFOVDisplay"));


		forceConst = 5;
		tinyMode = false;
	}

	void UpdateFOVDisplay(int newField){
		camera.GetComponent<Camera> ().fieldOfView = newField;
	}
}
