using UnityEngine;
using System.Collections;

public class FadeInTextOnScreen : MonoBehaviour {
	
	public Color endColor;
	public bool isVisible;
	public float delay;

	public TextMesh textMesh;

	public float fadeInTime;
	private float fadeInTimer;

	// Use this for initialization
	void Start () {
		isVisible = false;
		textMesh = gameObject.GetComponent<TextMesh> ();
		textMesh.renderer.material.color = Color.clear;
		fadeInTimer = -delay;
	}
	
	// Update is called once per frame
	void Update () {
		if (textMesh.renderer.isVisible) {
			isVisible = true;
		}

		if (isVisible) {
			fadeInTimer += Time.deltaTime;
			float prc = fadeInTimer/fadeInTime;
			float prcSq = Mathf.Pow(prc, 2);

			textMesh.renderer.material.color = Color.Lerp(textMesh.renderer.material.color, endColor, prcSq);
		}


	}
}
