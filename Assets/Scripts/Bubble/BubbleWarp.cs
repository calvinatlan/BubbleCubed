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
		//Smallest bubble size
		scaleS = transform.localScale;

		//Largest bubble size
		scaleL = new Vector3 (scaleS.x+.3f, scaleS.y+.3f, scaleS.z+.3f);

		//The delta size of the bubble (growth/shrink per loop)
		mini = new Vector3 (0.01f, 0.01f, 0.01f);
//		rising = true;

		StartCoroutine (changeSize ());
	}


	IEnumerator changeSize(){
		while (true) {
			//grow until you reach maximum size
			while (transform.localScale.x < scaleL.x) {
				transform.localScale += mini;
				yield return new WaitForSeconds(1/60f);
			}
			//shrink until you reach minimum size
			while (transform.localScale.x > scaleS.x) {
				transform.localScale -= mini;
				yield return new WaitForSeconds(1/60f);
			}

			//repeat forever until object is destroyed
		}
	}
}
