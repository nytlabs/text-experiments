using UnityEngine;
using System.Collections;

public class MoveCamWithButtons : MonoBehaviour {

	public bool isLeftPressed, isRightPressed, isSurfacePressed;
	public bool canMove;
	public float cameraSpeed;

	float startZ, endZ;

	// Use this for initialization
	void Start () {
		startZ = transform.position.z;
		endZ = transform.position.z - 2;
		canMove = true;
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

		float speed = 0.1F;
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			isSurfacePressed = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			isSurfacePressed = false;
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

	void OnCollisionEnter(Collision colInfo) {
		canMove = false;
	}
	void OnCollisionExit(Collision colInfo) {
		canMove = true;
	}
}
