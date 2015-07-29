using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {

	private Canvas deathMenu;
	public Button replay;
	public Button mainMenu;
	public Text correct;
	public Text wrong;
	public GameObject cube;
	private Player player;
	private AudioSource sE;
	public AudioClip laughter;
	public float laughterVol;
	// Use this for initialization
	void Start () {
		deathMenu = this.gameObject.GetComponent<Canvas>();
		player = cube.GetComponent<Player>();
		deathMenu.enabled = false;
		mainMenu = mainMenu.GetComponent<Button> ();
		replay = replay.GetComponent<Button> ();
		correct = correct.GetComponent<Text> ();
		wrong = wrong.GetComponent<Text> ();
		sE = gameObject.AddComponent<AudioSource> ();
	}
	public void cubeDestroyed(){
		correct.text = "Total Bubbles Collected: " + player.totalCount.ToString();
		wrong.text = "Total Wrong Bubbles: " + player.totalWrong.ToString();
		sE.clip = laughter;
		sE.volume = laughterVol;
		sE.Play ();
		deathMenu.enabled = true;
	}
	public void menuPress(){
		Application.LoadLevel(0);
	}
	public void replayPress(){
		Application.LoadLevel(1);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
