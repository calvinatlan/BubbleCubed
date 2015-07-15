using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	//Main cube
	private Player p;

	//For the swipes
	private Vector2 tDel;
	private float absMag;

	//For the tap
	private bool isTap;

	// Use this for initialization
	void Start () {
		p = (Player) this.gameObject.GetComponent("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//Do nothing if no fingers are down
		if (Input.touchCount == 0) {
			isTap = true;
			return;
		}

		Touch t = Input.GetTouch (0);
		tDel = t.deltaPosition;
		absMag = Mathf.Sqrt (tDel.magnitude);

		if (absMag > 5) {
			isTap = false;
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
		if (t.phase == TouchPhase.Ended && isTap) {
			if(t.position.x < (Screen.width / 3)){
				p.moveTo (0);
			}else if (t.position.x > (2 * Screen.width / 3)){
				p.moveTo (1);
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
