using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private Vector2 tDel;
	private float absMag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Do nothing if no fingers are down
		if (Input.touchCount == 0) {
			return;
		}

		Touch t = Input.GetTouch (0);
		tDel = t.deltaPosition;
		absMag = Mathf.Sqrt (tDel.magnitude);

		if (absMag > 5) {
			Player p = (Player) this.gameObject.GetComponent("Player");
			if(Mathf.Abs(tDel.x) > Mathf.Abs(tDel.y)){
				if (tDel.x > 0){
					p.rotateTo(2);
				}else{
					p.rotateTo(0);
				}
			}else{
				if (tDel.y > 0){
					p.rotateTo(1);
				}else{
					p.rotateTo (3);
				}
			}
		}

	}

//	IEnumerator touchM(Touch t){
//		while (Input.touchCount != 0) {
//			t = Input.GetTouch (0);
//			print (t.phase);
//			yield return null;
//		}
//	}
}
