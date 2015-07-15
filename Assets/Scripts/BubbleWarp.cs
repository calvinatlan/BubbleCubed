using UnityEngine;
using System.Collections;

public class BubbleWarp : MonoBehaviour {
	public float slope = 0.5f;
	public float interval = .01f;
	private Vector3 start;
	private float smooth = 0.5f;
	private float tNext = 0f;
	private float dir = 1f;



	// Use this for initialization


	void Start () {
		//start = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > tNext) {
			tNext += interval*(0.5f+Random.value);
			dir = -dir;
		}
		smooth += dir * slope * Time.deltaTime;
		if (smooth > 1f || smooth < 0.5f) {
			dir = -dir;
		}
		smooth = Mathf.Clamp (smooth, 0f, 0.5f);
		transform.localScale += new Vector3 (smooth*dir, 0f, 0f);

						
	}
}
