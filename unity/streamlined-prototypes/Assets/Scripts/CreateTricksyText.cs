using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTricksyText : MonoBehaviour {

	public string text1, text2;
	public GameObject text;
	List<GameObject> lines;
	public Camera camera;
	public float padding;
	public float z;
	public float startLeft;

	bool showText1;
	bool hasChangedAlready;

	float timer;

	public Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		showText1 = true;
		hasChangedAlready = false;
		lines = new List<GameObject> ();
		padding = .02f;

		MakeText (text1);
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (timer > .25f) {
			Debug.Log ("timer up");
			bool canSeeAnyText = false;

			for (int i = 0; i < lines.Count; i++) {
				if (lines[i].gameObject.GetComponent<TextMesh>().renderer.isVisible == true) {
					canSeeAnyText = true;
				}
			}

			if (canSeeAnyText == false && lines.Count > 0) {
				if (hasChangedAlready == false) {
					Destroy (GameObject.Find ("Parent"));
					Debug.Log ("changed");

					if (showText1) {
						MakeText(text2);
					} else {
						MakeText (text1);
					}

					showText1 = !(showText1);

					hasChangedAlready = true;
				}


			} else {
				hasChangedAlready = false;
			}

		}


	}

	void MakeText(string s) {
		timer = 0;
		lines.Clear ();
		
		string[] words = s.Split (' ');
		
		int curIndex = 0;

		GameObject p = new GameObject ("Parent");

		foreach (string word in words) {
			GameObject t = Instantiate (text, startPos, Quaternion.identity) as GameObject;
			curIndex++;
			lines.Add (t);
			TextMesh tm = (TextMesh)t.gameObject.GetComponent (typeof(TextMesh));
			tm.text = word;
		}

		for (int i = 0; i < words.Length; i++) {
			if (i != words.Length - 1) {
				int nextLine = i+1;
				
				if (i == 0) {
					lines[i].gameObject.transform.position = startPos;
				} else {
					lines[i].gameObject.transform.position = new Vector3(lines[i-1].gameObject.transform.position.x + lines[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, lines[i-1].transform.position.y, startPos.z);
				}
			
			}else{
				lines[i].gameObject.transform.position = new Vector3(lines[i-1].gameObject.transform.position.x + lines[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, lines[i-1].transform.position.y, lines[i-1].transform.position.z);
			}
			lines[i].transform.parent = p.transform;
		}


	}
}
