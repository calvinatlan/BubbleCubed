using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//How far the cube moves
	public float mD;
	//How long the cube takes to switch lanes
	public float speed;

	private enum lanes {Left, Middle, Right};
	private int curLane = (int)lanes.Middle;

	//Variables used for positional interpolation
	private Vector3 pos;
	private Vector3 target;
	private float startTime;
	private bool moving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	//This code checks if the player wants to move left or right, and makes sure they are not already moving
	//Then it calls a coroutine which moves the player smoothly one lane over
	void Movement(){
		if (!moving) {
			if (Input.GetAxis ("Horizontal") > 0 && curLane != (int)lanes.Right) {
				pos = transform.position;
				target = new Vector3 (pos.x + mD, pos.y, pos.z);
				startTime = Time.time;
				StartCoroutine ("Move");
				curLane++;
			} else if (Input.GetAxis ("Horizontal") < 0 && curLane != (int)lanes.Left) {
				pos = transform.position;
				target = new Vector3 (pos.x - mD, pos.y, pos.z);
				startTime = Time.time;
				StartCoroutine ("Move");
				curLane--;
			}
		}
	}

	IEnumerator Move(){
		moving = true;
		float track = 0f;
		while (track < 1f) {
			track = (Time.time - startTime) / speed;
			transform.position = Vector3.Lerp (pos, target, track);
			yield return null;
		}
		moving = false;
	}
}
