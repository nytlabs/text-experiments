using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatWord : MonoBehaviour {

	public List<string> wordsToFloat;
	private string myWord;
	public TextMesh textMesh;
	private bool shouldFloat;

	public float spawnTime;
	private float spawnTimer;

	private float timeOffset;

	public GameObject textToSpawn;

	// Use this for initialization
	void Start () {
		timeOffset = Random.Range (-5, 5);
		shouldFloat = false;
		textMesh = gameObject.GetComponent<TextMesh> ();

		for (int i = 0; i < wordsToFloat.Count; i++) {
			if (textMesh.text == wordsToFloat[i]) {
				myWord = wordsToFloat[i];
				shouldFloat = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (textMesh.renderer.material.color.a > .5f && shouldFloat) {
			spawnTimer += Time.deltaTime;
			bobWord ();
			if (spawnTimer > spawnTime) {
				spawnTimer = 0;
				GameObject t = Instantiate (textToSpawn, transform.position, Quaternion.identity) as GameObject;
				t.GetComponent<TextMesh>().text = myWord;
			}

		}


	}

	void bobWord() {
		float curZ = Mathf.Abs (transform.position.z + Mathf.Sin (Time.time + timeOffset) * .0005f) * -1;
		transform.position = new Vector3 (transform.position.x, transform.position.y, curZ);
	}
}
