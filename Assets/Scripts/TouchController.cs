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

		//Get the touch, it's movement vector, and the magnitude of that vector
		Touch t = Input.GetTouch (0);
		tDel = t.deltaPosition;
		absMag = Mathf.Sqrt (tDel.magnitude);

		//If the movement is large enough, it's a swipe
		if (absMag > 5) {
			//Flag it as not a tap so that the cube doesn't move when you lift your finger up
			isTap = false;
			//Figure out what direction the swipe is in
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
		//If the finger is lifted and it was not a swipe, execute this
		//Left third of the screen moves left, and right third moves right
		//There is a deadzone in the middle
		if (t.phase == TouchPhase.Ended && isTap) {
			if(t.position.x < (Screen.width / 3)){
				p.moveTo (0);
			}else if (t.position.x > (2 * Screen.width / 3)){
				p.moveTo (1);
			}
		}

	}
}
