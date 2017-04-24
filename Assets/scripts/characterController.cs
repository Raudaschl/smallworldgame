using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public GameObject camera;
	public float fieldOfView = 60;
	public float speed = 0.1f;
	public float forceConst = 5;
	public bool tinyMode = false;
	public bool canResize = false;
	public bool resizeArea = false;
	public AudioClip sizeDownSfx, sizeUpSfx;

	private AudioSource audio;
	private PickupObject pickupObjectCamera;
	private GameObject resizeIndicator;
	private GameObject musicObject;

	public bool canJump;
	private Rigidbody selfRigidbody;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();

		musicObject = GameObject.Find ("music");
		Cursor.lockState = CursorLockMode.Locked;
		selfRigidbody = GetComponent<Rigidbody>();

		pickupObjectCamera = camera.GetComponent<PickupObject> ();

		resizeIndicator = GameObject.Find("resizeIndicator");
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

		if(Input.GetKeyDown(KeyCode.Space)){
			if (this.GetComponent<Rigidbody> ().velocity.y == 0) {
				
			}
			canJump = true;
		}


	
	}

	void switchSize() {

		fieldOfView = camera.GetComponent<Camera> ().fieldOfView;

		if (canResize == true) {

			if (tinyMode == false) {
				scaleDown ();

			} else {
				scaleUp ();
			}
		}

	}


	public void canResizeFunction(){

			canResize = true;
			Debug.Log("Resize Active");
			resizeIndicator.GetComponent<resizeIndicator> ().enabledButton ();

	}

	public void cannotResizefunction(){

			canResize = false;
			Debug.Log("Resize Deactivated");
			resizeIndicator.GetComponent<resizeIndicator> ().disabledButton ();

	}



	public void scaleDown(){
		iTween.ScaleTo (gameObject, iTween.Hash ("scale", new Vector3 (0.05f, 0.05f, 0.05f), "easeType", "easeInOutExpo"));
		gameObject.GetComponent<Rigidbody> ().mass = 0.2f;


		audio.clip = sizeDownSfx;
		audio.Play ();
//		musicObject.GetComponent<AudioSource> ().pitch = 1.5f;
//		var currentRadius = gameObject.GetComponent<CapsuleCollider> ().radius;

		turnBigSizeCollisionOff (true);

		iTween.ValueTo (gameObject, iTween.Hash ("from", fieldOfView, "to", 80, "easeType", "easeInOutExpo", "onUpdate", "UpdateFOVDisplay"));



		forceConst = 0.7f;
		pickupObjectCamera.distance = pickupObjectCamera.smallDistance;

		SmallRadius ();
		speed = 0.03f;
		tinyMode = true;
	}

	public void scaleUp(){

		gameObject.GetComponent<CapsuleCollider> ().radius = 0.5f;

		iTween.ScaleTo (gameObject, iTween.Hash ("scale", new Vector3 (1f, 1f, 1f), "easeType", "easeInOutExpo"));
		gameObject.GetComponent<Rigidbody> ().mass = 1f;

		audio.clip = sizeUpSfx;
		audio.Play ();

//		musicObject.GetComponent<AudioSource> ().pitch = 1f;

		turnBigSizeCollisionOff (false);

		var currentRadius = gameObject.GetComponent<CapsuleCollider> ().radius;

		iTween.ValueTo (gameObject, iTween.Hash ("from", fieldOfView, "to", 60, "easeType", "easeInOutExpo", "onUpdate", "UpdateFOVDisplay"));


		forceConst = 5;
		speed = 0.1f;

		pickupObjectCamera.distance = pickupObjectCamera.bigDistance;
		tinyMode = false;
	}

	void turnBigSizeCollisionOff(bool enabled){
		GameObject[] bigCollisionObjects = GameObject.FindGameObjectsWithTag ("bigSizeCollision");


		foreach (GameObject bigCollisionObject in bigCollisionObjects) {
			Debug.Log (bigCollisionObject);
			bigCollisionObject.GetComponent<BoxCollider> ().isTrigger = enabled;
		}

				
	}

	void UpdateFOVDisplay(int newField){
		camera.GetComponent<Camera> ().fieldOfView = newField;
	}

	void SmallRadius(){
//		gameObject.GetComponent<CapsuleCollider> ().radius = 4;
	}
}
