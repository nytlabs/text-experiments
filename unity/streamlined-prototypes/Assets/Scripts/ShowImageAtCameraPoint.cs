using UnityEngine;
using System.Collections;

public class ShowImageAtCameraPoint : MonoBehaviour {

	private float midpoint;
	public float threshold;
	public GameObject image;
	private Camera cam;

	// Use this for initialization
	void Start () {
		midpoint = GameObject.Find ("swipehand").transform.position.x;
		cam = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.position.x > midpoint - threshold && camera.transform.position.x < midpoint + threshold && camera.transform.position.z > -210) {
			image.GetComponent<MoveSwipeUI> ().isVisible = true;
		} else {
			image.GetComponent<MoveSwipeUI> ().isVisible = false;
		}

	}
}
