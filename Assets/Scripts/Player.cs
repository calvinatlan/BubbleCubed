using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	//How far the cube moves
	public float mD;
	//How long the cube takes to switch lanes
	public float speed;
	//How fast the cube rotates
	public float rSpeed;

	private enum lanes {Left, Middle, Right};
	private int curLane = (int)lanes.Middle;

	//Variables used for positional interpolation
	private Vector3 pos;
	private Vector3 pTarget;
	private float mStartTime;
	private bool moving = false;

	//Variables used for rotational interpolation
	private Quaternion rot;
	private bool rotating = false;
	private float rStartTime;
	private Quaternion rTarget;
	private Vector3 cAxis;

	public int count;
	public Text countText;

	// Use this for initialization
	void Start () {
		count = 0;
		SetCount ();//updatecount

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Rotate();
		SetCount ();
	}

//Made this code simpler, calls 1 function
	void Movement(){
		if (Input.GetAxis ("Horizontal") > 0 ) {
			moveTo (0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			moveTo (1);
		}
	}

	void Rotate(){
			if (Input.GetAxis ("Rotate FB") > 0){
				moveTo (1);
			}else if (Input.GetAxis ("Rotate FB") < 0){
				moveTo (3);
			}else if (Input.GetAxis ("Rotate LR") > 0){
				moveTo (2);
			}else if (Input.GetAxis ("Rotate LR") < 0){
				moveTo (0);
			}
	}


	IEnumerator Move(){
		moving = true;
		float track = 0f;
		while (track < 1f) {
			track = (Time.time - mStartTime) / speed;
			transform.position = Vector3.Slerp (pos, pTarget, track);
			yield return null;
		}
		moving = false;
	}

	IEnumerator lRotate(){
		print ("rotating");
		rotating = true;
		float track = 0f;
		while (track < 1f){
			track = (Time.time - rStartTime) / rSpeed;
			transform.rotation = Quaternion.Lerp (rot, rTarget, track);
			yield return null;
		}
		rotating = false;
	}

	//This code checks if the player wants to move left or right, and makes sure they are not already moving
	//Then it calls a coroutine which moves the player smoothly one lane over

	//m is 0 for left, 1 for right
	public void moveTo(int m){
		if (!moving) {
			if (m == 1 && curLane != (int)lanes.Right) {
				pos = transform.position;
				pTarget = new Vector3 (pos.x + mD, pos.y, pos.z);
				mStartTime = Time.time;
				StartCoroutine ("Move");
				curLane++;
			} else if (m == 0 && curLane != (int)lanes.Left) {
				pos = transform.position;
				pTarget = new Vector3 (pos.x - mD, pos.y, pos.z);
				mStartTime = Time.time;
				StartCoroutine ("Move");
				curLane--;
			}
		}
	}

	//r is 0 for left, 1 for up, 2 for right, 3 for down
	public void rotateTo(int r){
		if (!rotating) {
			if (r == 0) {
				rot = transform.rotation;
				cAxis = Quaternion.Inverse (rot) * Vector3.down;
				rTarget = Quaternion.AngleAxis (90, cAxis);
				rTarget = rot * rTarget;
				rStartTime = Time.time;
				StartCoroutine ("lRotate");
			} else if (r == 1) {
				rot = transform.rotation;
				cAxis = Quaternion.Inverse (rot) * Vector3.right;
				rTarget = Quaternion.AngleAxis (90, cAxis);
				rTarget = rot * rTarget;
				rStartTime = Time.time;
				StartCoroutine ("lRotate");
			} else if (r == 2) { 
				rot = transform.rotation;
				cAxis = Quaternion.Inverse (rot) * Vector3.up;
				rTarget = Quaternion.AngleAxis (90, cAxis);
				rTarget = rot * rTarget;
				rStartTime = Time.time;
				StartCoroutine ("lRotate");
			} else if (r == 3) {
				rot = transform.rotation;
				cAxis = Quaternion.Inverse (rot) * Vector3.left;
				rTarget = Quaternion.AngleAxis (90, cAxis);
				rTarget = rot * rTarget;
				rStartTime = Time.time;
				StartCoroutine ("lRotate");
			}
		}
	}

	void SetCount(){
		countText.text = "Count: " + count.ToString ();
	}

	public int Count 
	{
		get 
		{ 
			return count; 
		}
		set 
		{
			count = value; 
		}
	}


}
