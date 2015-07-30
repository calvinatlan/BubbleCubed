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

		pauseMenu.enabled = true;

	
	}
	public void useUnpauseMenu(){

		pauseMenu.enabled = false;
			//music.mute = true;

	}
	public void menuPress(){
		Application.LoadLevel(0);
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
