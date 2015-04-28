using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBookstoreText : MonoBehaviour {

	public string InputText;
	public GameObject text;
	List<GameObject> lines;
	public Camera camera;
	public float padding;
	public float z;
	public float startLeft;

	// Use this for initialization
	void Start () {

		lines = new List<GameObject> ();
	
		string[] words = InputText.Split (' ');

		Vector3 startPos;
		if (startLeft == 0) {
			startPos = camera.ViewportToWorldPoint (new Vector3 (0, .5f, z));
		} else {
			startPos = new Vector3(startLeft, -4.2f, z);
		}
		int curIndex = 0;

		foreach (string word in words) {

			GameObject t = Instantiate (text, transform.position, Quaternion.identity) as GameObject;
//			t.GetComponent<LinkUp>().myNum = curIndex;
			curIndex++;
			lines.Add (t);
			TextMesh tm = (TextMesh)t.gameObject.GetComponent(typeof(TextMesh));
			tm.text = word;
//			if (tm.text == "director") {
//				t.gameObject.GetComponent<ReactToMouse>().shouldReact = true;
//			}
			Destroy(t.GetComponent<BoxCollider2D>());
			t.AddComponent<BoxCollider2D>().isTrigger = true;

//			t.GetComponent<BoxCollider2D>().isTrigger = true;
		}

		for (int i = 0; i < words.Length; i++) {
			if (i != words.Length - 1) {
				int nextLine = i+1;

				if (i == 0) {
					lines[i].gameObject.transform.position = startPos;
				} else {
					lines[i].gameObject.transform.position = new Vector3(lines[i-1].gameObject.transform.position.x + lines[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, lines[i-1].transform.position.y, startPos.z);
				}

//				SpringJoint2D joint = lines[i].gameObject.GetComponent<SpringJoint2D>();

//				joint.connectedBody = lines[nextLine].gameObject.rigidbody2D;
//				joint.enabled = false;

			}else{
				lines[i].gameObject.transform.position = new Vector3(lines[i-1].gameObject.transform.position.x + lines[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, lines[i-1].transform.position.y, lines[i-1].transform.position.z);
//				Destroy(lines[i].gameObject.GetComponent<HingeJoint2D>());

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
