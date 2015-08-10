using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private Canvas pauseMenu;
	public Button unpause;

	// Use this for initialization
	void Start () {
		pauseMenu = this.gameObject.GetComponent<Canvas>();
		pauseMenu.enabled = false;
	}
	public void usePauseMenu(){
		if (pauseMenu.enabled == false) {
			pauseMenu.enabled = true;
			Time.timeScale = 0;
			AudioListener.pause = true;
		}
		else {
			pauseMenu.enabled = false;
			Time.timeScale = 1;
			AudioListener.pause = false;
		}
	
	}
	public void useUnpauseMenu(){

		pauseMenu.enabled = false;
		
	}




	public void menuPress(){
		AudioListener.pause = true;
		Application.LoadLevel(0);
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
