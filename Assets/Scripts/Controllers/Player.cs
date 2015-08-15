using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public static bool isAlive;
	//How far the cube moves
	public float mD;
	//How long the cube takes to switch lanes
	public float speed;
	//How fast the cube rotates
	public float rSpeed;

	private GameObject rainbowSide1;
	private GameObject rainbowSide2;
	private GameObject rainbowSide3;
	private GameObject rainbowSide4;
	private GameObject rainbowSide5;
	private GameObject rainbowSide6;
	private bool isRainbow = false;

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

	public int gamePoints;
	public int totalCount;
	public int totalWrong;
	public float health;
	public int counts;
	public int highStreak;
	public int num;
	public Text countText;
	public Text streakText;
	public Text healthBar;
	public Text scoreText;
	public Text multiplierText;
	public Text notificationText;

	public Slider streakSlider;
	public Slider healthSlider; 
	public float startingHealth = 100;

	//variables for audio
	public float gameOverVol;
	public float gameStartVol;
	public float seVol;
	public AudioClip gameOver;
	public AudioClip gameStart;
	public AudioClip rainbowSong;
	public AudioClip rainbow;
	public AudioClip laneSwitch;
	public AudioClip [] rotate = new AudioClip[2];
	private AudioSource music;
	private AudioSource sE;
	private AudioSource voice;
	private AudioSource music2;

	public Image healthFill;
	public Color MaxHealthColor = Color.green;
	public Color MinHealthColor = Color.red;

	public Image streakFill;
	public Color MaxStreakColor = Color.blue;
	public Color MinStreakColor = Color.blue;

	//DeathMenu
	public GameObject canvas;
	public GameObject canvas2;

	//PauseMenu
	public GameObject canvas3;

	//For explosion effect
	private GameObject explosionCube;
	
	// Use this for initialization
	void Start () {
		//Create bgm audiosource
		isAlive = true;
		music = gameObject.AddComponent<AudioSource> ();
		music.clip = gameStart;
		music.volume = gameStartVol;
		music.loop = true;
		music.Play();
		music2 = gameObject.AddComponent<AudioSource> ();
		music2.clip = rainbowSong;
		//Sample Notification 
		StartCoroutine (notification("Welcome to Bubble Cubed!"));

		Time.timeScale = 1;

		//Create pop audiosource
		sE = gameObject.AddComponent<AudioSource> ();
		sE.volume = seVol;
		voice = gameObject.AddComponent<AudioSource> ();
		voice.volume = seVol;
		voice.clip = rainbow;

		gamePoints = 0;
		counts = 0;
		highStreak = counts;
		health = startingHealth;
		num = (int)health;
		counter ();//updatecount
		healthBarInitial ();

		rainbowSide1 =  GameObject.FindGameObjectWithTag ("Rainbow Side");
		rainbowSide1.SetActive (false);
		rainbowSide2 =  GameObject.FindGameObjectWithTag ("Rainbow Side 2");
		rainbowSide2.SetActive (false);
		rainbowSide3 =  GameObject.FindGameObjectWithTag ("Rainbow Side 3");
		rainbowSide3.SetActive (false);
		rainbowSide4 =  GameObject.FindGameObjectWithTag ("Rainbow Side 4");
		rainbowSide4.SetActive (false);
		rainbowSide5 =  GameObject.FindGameObjectWithTag ("Rainbow Side 5");
		rainbowSide5.SetActive (false);
		rainbowSide6 =  GameObject.FindGameObjectWithTag ("Rainbow Side 6");
		rainbowSide6.SetActive (false);

		explosionCube = (GameObject)Resources.Load ("Cube Explosion");
	}

	
	// Update is called once per frame
	void Update () {
		Movement ();
		Rotate();
		canvasUpdate ();
		multiplier ();
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
			sE.clip = laneSwitch;
			sE.Play();
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
			sE.clip = rotate[Random.Range (0,1)];
			sE.Play ();
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
		//change value in order to change the lag for changing lane
		yield return new WaitForSeconds (0.13f);
		moving = false;
	}

	//Coroutine that uses lerp to rotate the cube
	IEnumerator lRotate(){
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
		if(canvas != null)
			countText.text = "Count: " + counts.ToString ();
			streakSlider.value = counts;
	}
	void score(){
		if(canvas != null)
			scoreText.text = "Score: " + gamePoints.ToString ();
	}

	void highStreakText(){
		if(counts > highStreak){
			highStreak = counts;
			streakSlider.maxValue = highStreak;
		}
		streakText.text = "Streak: " + counts.ToString () + "/" + highStreak.ToString();
		if(canvas != null)
			countText.text = "Count: " + counts.ToString ();
	}
//
//	void highStreakText(){
//		if (canvas != null){
//			if (counts > highStreak) {
//				highStreak = counts;
//			}
//			streakText.text = "High Streak: " + highStreak.ToString ();
//		}
//	}

	void canvasUpdate(){
		if (canvas != null) {
			highStreakText ();
			counter ();
			score();
			health -= (2 * Time.deltaTime);
			healthFill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)health / startingHealth);
			streakFill.color = Color.Lerp (MinStreakColor,MaxStreakColor, (float)counts/highStreak);
			healthBarInitial ();

			pause();
			//Pause button-----------------------
//			if (Input.GetKeyDown ("p")) {
//				if(Time.timeScale == 1){
//					Time.timeScale = 0;
//					music.mute = true;
//					//pause1.usePauseMenu();
//				}
//				else{
//					Time.timeScale = 1;
//					music.mute = false;
//					//pause1.useUnpauseMenu();
//				}
//			}
//			//-----------------------------------	
		}

	}

	public void pause(){
		PauseMenu pause1 = (PauseMenu) canvas3.GetComponent("PauseMenu");
		//Pause button-----------------------
		if (Input.GetKeyDown ("p")) {
			if(Time.timeScale == 1){
				Time.timeScale = 0;
				music.mute = true;
				pause1.usePauseMenu();
			}
			else{
				Time.timeScale = 1;
				music.mute = false;
				pause1.useUnpauseMenu();
				AudioListener.pause = false;
			}
		}
		//-----------------------------------

	}

	public void buttonpause(){
		PauseMenu pause1 = (PauseMenu) canvas3.GetComponent("PauseMenu");

		if(Time.timeScale == 1){
			Time.timeScale = 0;
			music.mute = true;
			pause1.usePauseMenu();
		}
		if(Time.timeScale == 0){
			Time.timeScale = 1;
			music.mute = false;
			pause1.useUnpauseMenu();
		}

		
	}          

	void healthBarInitial(){
		num = (int)health;

		if (Input.GetKeyDown ("k")) {
			health = 0;
		}

		if (health <= 0) {
			health = 0;
			healthSlider.value = health;
			healthBar.text = "Game Over";

			isAlive = false;
			Destroy(gameObject);
			if(gamePoints > PlayerPrefs.GetInt("score0")){
				PlayerPrefs.SetInt("score0", gamePoints);
			}
			else if(gamePoints > PlayerPrefs.GetInt("score1")){
				PlayerPrefs.SetInt("score1", gamePoints);
			}
			else if(gamePoints > PlayerPrefs.GetInt("score2")){
				PlayerPrefs.SetInt("score2", gamePoints);
			}
			//gets rid of background text during the deathMenu

			Instantiate (explosionCube, transform.position, transform.rotation);

			Destroy(canvas);

			DeathMenu menu = (DeathMenu) canvas2.GetComponent("DeathMenu");
			menu.cubeDestroyed();
			//if game music is still gameStart music
			//change it to gameOver music
			if(music.clip != gameOver){
				music.Stop();
				music.clip = gameOver;
				music.loop = true;
				music.volume = gameOverVol;
				music.Play();
			}

			
		}
		else{
			if (health > startingHealth){
				health = startingHealth;
				healthSlider.value = health;
				healthBar.text = "Health: 100%";
				//Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)health / 100);
			}
			else{
				healthBar.text = "Health: " + num.ToString () +"%";
				healthSlider.value = health;
			}
		}

	}

	public bool getRainbow()
	{
		return isRainbow;
	}
	
	public IEnumerator turnToRainbow ()
	{
		isRainbow = true;
		if (GameController.multiplier<2) GameController.multiplier++;
		//play rainbow song
		music.Pause ();
		music2.Play ();
		voice.Play ();
		rainbowSide1.SetActive (true);
		rainbowSide2.SetActive (true);
		rainbowSide3.SetActive (true);
		rainbowSide4.SetActive (true);
		rainbowSide5.SetActive (true);
		rainbowSide6.SetActive (true);
		StartCoroutine (waitAndThen());
		yield return null;
	}
	public IEnumerator waitAndThen()
	{

		yield return new WaitForSeconds (5);
		if (GameController.multiplier==2)GameController.multiplier--;
		isRainbow = false;
		rainbowSide1.SetActive (false);
		rainbowSide2.SetActive (false);
		rainbowSide3.SetActive (false);
		rainbowSide4.SetActive (false);
		rainbowSide5.SetActive (false);
		rainbowSide6.SetActive (false);
		//resume playing game music
		music2.Stop ();
		music.UnPause ();

	}
	public void notificationFunc (string s)
	{
		StopCoroutine ("notification");
		StartCoroutine ("notification",s);
	}

	public IEnumerator notification(string notif)
	{
		notificationText.text = notif;
		notificationText.color = Color.clear;
		for (int i=0; i<100; i++) 
		{
			notificationText.color = Color.Lerp(Color.clear, Color.white, (float)(i/(100f)));
			yield return new WaitForSeconds (0.01f);
		}
		notificationText.color = Color.white;
		yield return new WaitForSeconds (1f);
		for (int j=0; j<100; j++) 
		{
			notificationText.color = Color.Lerp(Color.white, Color.clear, (float)(j/(100f)));
			yield return new WaitForSeconds (0.01f);
		}
		
	}

	public IEnumerator textFader(Text a)
	{
		a.color = Color.clear;
		for (int i=0; i<100; i++) 
		{
			a.color = Color.Lerp(Color.clear, Color.white, (float)(i/(100f)));
			yield return new WaitForSeconds (0.01f);
		}
		a.color = Color.white;
		yield return new WaitForSeconds (1f);
		for (int j=0; j<100; j++) 
		{
			a.color = Color.Lerp(Color.white, Color.clear, (float)(j/(100f)));
			yield return new WaitForSeconds (0.01f);
		}
		
	}

	//-------------------Point scoring functions---------------//
	//--------------------------------------------------------//
	public void healthPoints(int s){

		counts++;
		totalCount++;
		//added multiplier to help keep your hp up high when on a streak
		//might need to be balanced
		health+=s * multiplier();
	}
	
	public void addPoints(int pointsWorth){
		gamePoints += pointsWorth * multiplier();
	}
	
	private int multiplier(){
		int num = 0;
		int mult = (counts-1) / 10;
		int maxMltiplier = 5;
		
		//multiplier 0 through 5
		if(counts < 11){
			num = 1;
			multiplierText.color = Color.clear;
			StopCoroutine (textFader(multiplierText));
		}
		else if (mult < maxMltiplier) {
			num = mult + 1;
			multiplierText.text = "x " + num.ToString ();
			//multiplierText.color = Color.white;

			if((counts -1)%10 == 0){
				StopCoroutine ("textFader");
				StartCoroutine ("textFader",multiplierText);
				
				StopCoroutine ("notification");
				StartCoroutine ("notification","x" + num.ToString() + " Multiplier Reached!");
			}
		} 
		//multiplier set to max
		else{
			num = maxMltiplier;
			multiplierText.text = "x " + num.ToString ();
			multiplierText.color = Color.white;

			notificationText.color = Color.white;
		} 
		
		return num;
	}
	
	public void startHealthUp(){
		
		if (startingHealth <= 190) 
		{
			startingHealth += 10;
			health = startingHealth;
		}
	}
	
	public void hurt(int s){
		health-=s;
		totalWrong++;
		counts = 0;
	}
	
	//--------------------------------------------------------//
	//--------------------------------------------------------//
}
