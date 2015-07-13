using UnityEngine;
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Rotate();
	}

	//This code checks if the player wants to move left or right, and makes sure they are not already moving
	//Then it calls a coroutine which moves the player smoothly one lane over
	void Movement(){
		if (!moving) {
			if (Input.GetAxis ("Horizontal") > 0 && curLane != (int)lanes.Right) {
				pos = transform.position;
				pTarget = new Vector3 (pos.x + mD, pos.y, pos.z);
				mStartTime = Time.time;
				StartCoroutine ("Move");
				curLane++;
			} else if (Input.GetAxis ("Horizontal") < 0 && curLane != (int)lanes.Left) {
				pos = transform.position;
				pTarget = new Vector3 (pos.x - mD, pos.y, pos.z);
				mStartTime = Time.time;
				StartCoroutine ("Move");
				curLane--;
			}
		}
	}

	void Rotate(){
		if (!rotating){
			if (Input.GetAxis ("Rotate FB") > 0){
				rot = transform.rotation;
				rTarget = rot * Quaternion.Euler(90f,0f,0f);
				rStartTime = Time.time;
				StartCoroutine("lRotate");
			}else if (Input.GetAxis ("Rotate FB") < 0){
				rot = transform.rotation;
				rTarget = rot * Quaternion.Euler(-90f,0f,0f);
				rStartTime = Time.time;
				StartCoroutine("lRotate");
			}else if (Input.GetAxis ("Rotate LR") > 0){
				rot = transform.rotation;
				rTarget = rot * Quaternion.Euler(0f,90f,0f);
				rStartTime = Time.time;
				StartCoroutine("lRotate");
			}else if (Input.GetAxis ("Rotate LR") < 0){
				rot = transform.rotation;
				rTarget = rot * Quaternion.Euler(0f,-90f,0f);
				rStartTime = Time.time;
				StartCoroutine("lRotate");
			}

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
}
