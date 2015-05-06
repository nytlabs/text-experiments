using UnityEngine;
using System.Collections;

public class FloatWordForward : MonoBehaviour {

	private float startZ;
	private float endZ;
	private float curZ;
	public float speedZ;
	public float maxOffset;
	private float offset;

	private Color startColor;

	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		startZ = transform.position.z;
		curZ = startZ;
		endZ = Camera.main.transform.position.z/20;
		textMesh = gameObject.GetComponent<TextMesh> ();
		offset = Random.Range (-maxOffset, maxOffset);

		startColor = new Color (.75f, .75f, .75f, .2f);
	}
	
	// Update is called once per frame
	void Update () {
		curZ -= speedZ * Time.deltaTime;

		transform.position = new Vector3 (transform.position.x + Mathf.Sin(Time.time) *.0001f, transform.position.y+ Mathf.Cos(Time.time) *.0001f, curZ);

		textMesh.color = Color.Lerp (startColor, Color.clear, curZ / endZ);

		if (textMesh.color == Color.clear) {
			Destroy (gameObject);
		}

	}
}
