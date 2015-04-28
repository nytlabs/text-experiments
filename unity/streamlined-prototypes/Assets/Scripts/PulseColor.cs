using UnityEngine;
using System.Collections;

public class PulseColor : MonoBehaviour {

	float offset;

	private Color clear;
	private Color endColor;

	// Use this for initialization
	void Start () {
		clear = new Color (255, 255, 255, .6f);
//		white = new Color (255, 255, 255, 1);
		endColor = renderer.material.color;
		clear = new Color (endColor.r, endColor.g, endColor.b, .6f);

		offset = Random.Range (0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = Color.Lerp (clear, endColor, Mathf.Abs (Mathf.Sin(Time.time + offset)));
	}
}
