using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateLookbackText : MonoBehaviour {

	public string InputText;
	public GameObject text;
	List<GameObject> texts;
	public Camera camera;
	public float padding;
	public float z;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {

		texts = new List<GameObject> ();
	
		string[] words = InputText.Split (' ');
		Debug.Log (InputText);

		int curIndex = 0;

		padding = .02f;

		foreach (string word in words) {

			GameObject t = Instantiate (text, transform.position, Quaternion.identity) as GameObject;
			curIndex++;
			texts.Add (t);
			TextMesh tm = (TextMesh)t.gameObject.GetComponent(typeof(TextMesh));
			tm.text = word;
		
		}

		for (int i = 0; i < words.Length; i++) {
			if (i != words.Length - 1) {
				int nextLine = i+1;

				if (i == 0) {
					texts[i].gameObject.transform.position = startPos;
				} else {
					texts[i].gameObject.transform.position = new Vector3(texts[i-1].gameObject.transform.position.x + texts[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, texts[i-1].transform.position.y, startPos.z);
				}

			}else{
				texts[i].gameObject.transform.position = new Vector3(texts[i-1].gameObject.transform.position.x + texts[i-1].gameObject.GetComponent<TextMesh>().renderer.bounds.size.x + padding, texts[i-1].transform.position.y, texts[i-1].transform.position.z);

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
