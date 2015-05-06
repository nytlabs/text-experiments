using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSpringText2 : MonoBehaviour {
	
	public string InputText;
	public GameObject text;
//	public GameObject mouse;

	public GameObject leftStake;
	public GameObject rightStake;

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
				joint.anchor = new Vector2(lines[i].gameObject.renderer.bounds.size.x, 0);
				//				joint.enabled = false;
				
				Debug.Log(words[i] + " connects "+words[nextLine]);
			}else{
				lines[i].gameObject.GetComponent<SpringJoint2D>().connectedBody = rightStake.rigidbody2D;
				SpringJoint2D joint = lines[i].gameObject.GetComponent<SpringJoint2D>();
				joint.anchor = new Vector2(lines[i].gameObject.renderer.bounds.size.x, 0);
			}

			if (i==0) {
				leftStake.GetComponent<SpringJoint2D>().connectedBody = lines[i].rigidbody2D;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
