using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSpringText : MonoBehaviour {

	public string InputText;
	public GameObject text;
	public GameObject mouse;
	List<GameObject> lines;

	// Use this for initialization
	void Start () {

		lines = new List<GameObject> ();
	
		string[] words = InputText.Split (' ');

		int curIndex = 0;
		foreach (string word in words) {
			GameObject t = Instantiate (text, transform.position, Quaternion.identity) as GameObject;
//			t.GetComponent<LinkUp>().myNum = curIndex;
			curIndex++;
			lines.Add (t);
			TextMesh tm = (TextMesh)t.gameObject.GetComponent(typeof(TextMesh));
			tm.text = word;
			Destroy(t.GetComponent<BoxCollider2D>());
			t.AddComponent<BoxCollider2D>();
		}

		for (int i = 0; i < words.Length; i++) {
			if (i != words.Length - 1) {
				int nextLine = i+1;

				SpringJoint2D joint = lines[i].gameObject.GetComponent<SpringJoint2D>();

				joint.connectedBody = lines[nextLine].gameObject.rigidbody2D;
//				joint.enabled = false;

				Debug.Log(words[i] + " connects "+words[nextLine]);
			}else{
				Destroy(lines[i].gameObject.GetComponent<SpringJoint2D>());
			}

			if (i == 0) {
				mouse.GetComponent<SpringJoint2D>().connectedBody = lines[i].rigidbody2D;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
