using UnityEngine;
using System.Collections;

public class MousePush : MonoBehaviour {

	public float speed;
	private Vector3 target;
	private Vector3 start;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		start = transform.position;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint (pos);
		transform.position = new Vector3 (pos.x, pos.y, transform.position.z);

//		transform.position = Vector3.Lerp (transform.position, pos, speed * Time.deltaTime);
	}
}
