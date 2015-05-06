using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			Debug.Log(touch.tapCount);
		}


		if (Input.GetKeyDown ("2")) {
			Application.LoadLevel("Scene2");
		}

		if (Input.GetKeyDown ("3")) {
			Application.LoadLevel("Scene3");
		}

		if (Input.GetKeyDown ("4")) {
			Application.LoadLevel("Scene4");
		}

		if (Input.GetKeyDown ("5")) {
			Application.LoadLevel("Scene5");
		}

		if (Input.GetKeyDown ("6")) {
			Application.LoadLevel("Scene6");
		}

		if (Input.GetKeyDown ("7")) {
			Application.LoadLevel("Scene7");
		}
		if (Input.GetKeyDown ("8")) {
			Application.LoadLevel("Scene8");
		}
		if (Input.GetKeyDown ("9")) {
			Application.LoadLevel("Scene9");
		}
		if (Input.GetKeyDown ("0")) {
			Application.LoadLevel("Scene10");
		}
		if (Input.GetKeyDown ("1")) {
			Application.LoadLevel("Scene11");
		}





	}


}
