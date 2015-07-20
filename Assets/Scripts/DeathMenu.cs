using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {

	private Canvas deathMenu;
	//public Button replay;
	public Button mainMenu;

	// Use this for initialization
	void Start () {
		deathMenu = (Canvas) this.gameObject.GetComponent("Canvas");
		deathMenu.enabled = false;
		mainMenu = mainMenu.GetComponent<Button> ();
		//replay = replay.GetComponent<Button> ();
	}
	public void cubeDestroyed(){
		deathMenu.enabled = true;
	}
	public void menuPress(){
		Application.LoadLevel(0);
	}
	/*public void replayPress(){
		Application.LoadLevel(1);
	}*/
	// Update is called once per frame
	void Update () {
	
	}
}
