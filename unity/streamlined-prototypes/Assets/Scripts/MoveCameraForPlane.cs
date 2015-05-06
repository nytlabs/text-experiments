using UnityEngine;
using System.Collections;

public class MoveCameraForPlane : MonoBehaviour {

	public bool isLeftPressed, isRightPressed, isSurfacePressed;
	public bool canMove;
	public float cameraSpeed;

	public bool triggerEnd;
	public float startEndSpeed;

	
	float startZ, endZ;
	
	// Use this for initialization
	void Start () {
		startZ = transform.position.z;
		endZ = transform.position.z - 2;
		canMove = true;
		triggerEnd = false;
		startEndSpeed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			isRightPressed = true;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			isRightPressed = false;
		}
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			isLeftPressed = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			isLeftPressed = false;
		}
		
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			isSurfacePressed = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			isSurfacePressed = false;
		}

		
		if (camera.transform.position.x >= 5.75f) {
			canMove = false;
			triggerEnd = true;
		}

		if (camera.transform.position.x >= 18.37504f) {
			Application.LoadLevel("Scene5");
		}
		
		if (triggerEnd) {
			AudioSource sfx = gameObject.GetComponent<AudioSource>();

			if (sfx.isPlaying == false) {
				sfx.Play ();
			}

			startEndSpeed *= 1.003f;
			transform.position = new Vector3(transform.position.x + startEndSpeed, transform.position.y, transform.position.z);
		}

		
		if (canMove) {
			if (isLeftPressed) {
				transform.position = new Vector3 (transform.position.x - cameraSpeed, transform.position.y, transform.position.z);
			}
			if (isRightPressed) {
				transform.position = new Vector3 (transform.position.x + cameraSpeed, transform.position.y, transform.position.z);
			}
		}
		
		
		if (isSurfacePressed) {
			if (transform.position.z > endZ) {
				Debug.Log ("it is");
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - .1f);
			}
		} else {
			if (transform.position.z < startZ) {
				Debug.Log ("it is");
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + .1f);
			}
		}
		
	}
}
