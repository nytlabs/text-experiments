using UnityEngine;
using System.Collections;

public class MoveCamWithSwipe : MonoBehaviour {
	public float speed;
	
	public bool yMovementEnabled;
	public float minimumYToTrigger;
	public float zSpeed;

	public bool isPlaneScene;

	private bool shouldSlideVertically;

	private float startZ;
	private float endZ;

	private bool canMoveUp;

	private float friction;
	private Vector2 velocity;

	private float frictionTimer;
	public float frictionTime;

	private float length = 0;
	private bool SW = false;
	private Vector3 final;
	private Vector3 startpos;
	private Vector3 endpos;

	private Vector2 currentPosition, deltaPosition, lastPosition;
	// Use this for initialization
	void Start () {
		startZ = transform.position.z;
		endZ = startZ - 2;

		if (speed == 0) {
			speed = 0.001f;
		}
		friction = .99f;
		frictionTime = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaneScene) {
			if (gameObject.GetComponent<MoveCameraForPlane> ().triggerEnd == false) {
				CheckForMovement ();
			}
		} else {
			CheckForMovement();
		}

	}

	void CheckForMovement() {
		if (Input.GetMouseButtonDown(0)) {
			final = Vector3.zero;
			length = 0; 
			SW = false;
			Vector2 touchDeltaPosition = Input.mousePosition;
			startpos = new Vector3(touchDeltaPosition.x, 0, touchDeltaPosition.y);
			
		}
		
		Vector3 comparePos = new Vector3 (Input.mousePosition.x, 0, Input.mousePosition.y);
		
		if (Input.GetMouseButton (0) && startpos != comparePos) {
			SW = true;
		}
		
		if (Input.GetMouseButton (0) && startpos == comparePos) {
			SW = false;
		}
		
		if (Input.GetMouseButtonUp (0) && startpos != comparePos) {
			if (SW) {
				Vector2 position = Input.mousePosition;
				endpos = new Vector3(position.x, 0, position.y);
				final = endpos - startpos;
				length = final.magnitude;
				Vector3 normalized = final.normalized;

				AddForces();
				
			}
		}

		if (Input.GetMouseButtonUp (0) && startpos == comparePos) {
			rigidbody2D.velocity = Vector2.zero;
		}

		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x * friction, 0);

		if (shouldSlideVertically) {
			if (Mathf.Sign (final.z) == -1) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zSpeed);
			} else {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed);
			}
		}

		if (transform.position.z < endZ) {
			shouldSlideVertically = false;
			transform.position = new Vector3(transform.position.x, transform.position.y, endZ);
		}
		if (transform.position.z > startZ) {
			shouldSlideVertically = false;
			transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
		}
	}

	void AddForces() {
		Vector3 forceToApply = final * speed;

		if (yMovementEnabled) {
			rigidbody2D.AddForce (new Vector2(-forceToApply.x,0));
			if (Mathf.Abs(forceToApply.z) > minimumYToTrigger) {
				shouldSlideVertically = true;
			}
		} else {
			rigidbody2D.AddForce (new Vector2(-forceToApply.x, 0));
		}

	}
}
