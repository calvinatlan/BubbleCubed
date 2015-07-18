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

	public float health;
	public int counts;
	public int highStreak;
	public int num;
	public Text countText;
	public Text streakText;
	public Text healthBar;

	// Use this for initialization
	void Start () {
		counts = 0;
		highStreak = counts;
		health = 100;
		num = (int)health;
		counter ();//updatecount
		healthBarInitial ();

	}

	
	// Update is called once per frame
	void Update () {
		Movement ();
		Rotate();
		highStreakText ();
		counter ();
		health -= Time.deltaTime;
		healthBarInitial ();
	}

//Made this code simpler, calls moveTo function
	void Movement(){
		if (Input.GetAxis ("Horizontal") > 0 ) {
			moveTo (1);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			moveTo (0);
		}
	}

//Made this code simpler, calls rotate function
	void Rotate(){
			if (Input.GetAxis ("Rotate FB") > 0){
				rotateTo (1);
			}else if (Input.GetAxis ("Rotate FB") < 0){
				rotateTo (3);
			}else if (Input.GetAxis ("Rotate LR") > 0){
				rotateTo (2);
			}else if (Input.GetAxis ("Rotate LR") < 0){
				rotateTo (0);
			}
	}

	//This code checks if the player wants to move left or right, and makes sure they are not already moving
	//Then it calls a coroutine which moves the player over using lerp
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

	//Figures out correct axis accounting for current rotation
	//Starts a coroutine that spins the cube 90 degrees around that axis using lerp
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

	//Coroutine that uses lerp to translate the cube
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

	//Coroutine that uses lerp to rotate the cube
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

	void counter(){
		countText.text = "Count: " + counts.ToString ();
	}
	void highStreakText(){
		if(counts > highStreak){
			highStreak = counts;
		}
		streakText.text = "High Streak: " + highStreak.ToString();
	}

	void healthBarInitial(){
		num = (int)health;

		if(health < 0){
			health = 0;
			healthBar.text = "Game Over";
		}
		else{
			if (health > 100){
				health = 100;
				healthBar.text = "Health: 100%";
			}
			else{
				healthBar.text = "Health: " + num.ToString () +"%";
			}

		}

	}




}
