using UnityEngine;
using System.Collections;

public class GetHeld : MonoBehaviour {

	public bool isHeld;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isHeld == true) {

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			obj = hit.collider.gameObject;
			transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
			
			
//			obj.transform.position = new Vector3(mousePos.x, mousePos.y, hit.collider.gameObject.transform.position.z);
		}

	}
}
