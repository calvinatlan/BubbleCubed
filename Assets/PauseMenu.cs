using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private Canvas pauseMenu;
	public Button unpause;
	public Button mainMenu;
	public GameObject cube;
	private Player player;

	// Use this for initialization
	void Start () {
		pauseMenu = this.gameObject.GetComponent<Canvas>();
		pauseMenu.enabled = false;
		player = cube.GetComponent<Player>();
		mainMenu = mainMenu.GetComponent<Button> ();
		unpause = unpause.GetComponent<Button> ();

	}
	public void usePauseMenu(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseMenu.enabled = true;
			//music.mute = true;
		}
	
	}
	public void useUnpauseMenu(){
		if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseMenu.enabled = false;
			//music.mute = true;
		}
	}
	public void menuPress(){
		Application.LoadLevel(0);
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
