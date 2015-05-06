using UnityEngine;
using System.Collections;

public class DragWord : MonoBehaviour {

	GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 500);
			if (hit.collider != null) {
				obj = hit.collider.gameObject;
				obj.GetComponent<GetHeld>().isHeld = true;
			}
		}

		if (Input.GetMouseButtonUp (0) && obj!=null) {
			obj.GetComponent<GetHeld>().isHeld = false;
		}

	}

}
