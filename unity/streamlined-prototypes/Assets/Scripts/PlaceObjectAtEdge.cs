using UnityEngine;
using System.Collections;

public class PlaceObjectAtEdge : MonoBehaviour {

	public bool top, middle, bottom;
	public bool left, right, center;
	private float l, b;
	private float offsetX;

	// Use this for initialization
	void Start () {

		offsetX = 0;

		if (top) {
			b = Camera.main.pixelHeight;
		}
		if (middle) {
			b = Camera.main.pixelHeight/2;
		}
		if (bottom) {
			b = 0;
		}

		if (left) {
			l = 0 + offsetX;
		}
		if (center) {
			l = Camera.main.pixelWidth/2;
		}
		if (right) {
			l = Camera.main.pixelWidth - offsetX;
		}

		Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (l, b, Camera.main.nearClipPlane));
		transform.position = p;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
