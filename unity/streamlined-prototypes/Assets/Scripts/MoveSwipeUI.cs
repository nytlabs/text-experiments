using UnityEngine;
using System.Collections;

public class MoveSwipeUI : MonoBehaviour {

	public bool isVisible;
	private float startY;
	public float endY;

	public float speedY;

	public Color endColor;

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		isVisible = false;
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isVisible == false) {
			transform.position = new Vector3(transform.position.x, startY, transform.position.z);
			sprite.color = Color.clear;
		}

		if (isVisible == true) {
			if (transform.position.y > endY) {
				transform.position = new Vector3(transform.position.x, transform.position.y - speedY, transform.position.z);

				float prc = (transform.position.y - startY)/(endY - startY);

				sprite.color = Color.Lerp(endColor, Color.clear, prc);
			} else {
				transform.position = new Vector3(transform.position.x, startY, transform.position.z);
			}

		}


	
	}
}
