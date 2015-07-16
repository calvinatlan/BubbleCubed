using UnityEngine;
using System.Collections;

public class BubbleWarp : MonoBehaviour {
	private Vector3 scaleS;
	private Vector3 scaleL;
	private Vector3 rStart;
	private Vector3 mini;
//	private bool rising;

	// Use this for initialization


	void Start () {
		scaleS = transform.localScale;
		scaleL = new Vector3 (scaleS.x+.3f, scaleS.y+.3f, scaleS.z+.3f);
		mini = new Vector3 (0.01f, 0.01f, 0.01f);
//		rising = true;

		StartCoroutine (changeSize ());
	}

	IEnumerator changeSize(){
		while (true) {
			while (transform.localScale.x < scaleL.x) {
				transform.localScale += mini;
				yield return new WaitForSeconds(1/60f);
			}
			while (transform.localScale.x > scaleS.x) {
				transform.localScale -= mini;
				yield return new WaitForSeconds(1/60f);
			}
		}
	}
}
