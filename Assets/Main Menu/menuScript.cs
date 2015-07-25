using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas creditMenu;
	public Canvas scoreMenu;

	public Button startText;
	public Button exitText;
	public Button mainMenu;

	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		creditMenu = creditMenu.GetComponent<Canvas> ();
		scoreMenu = scoreMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		mainMenu = mainMenu.GetComponent<Button> ();
		quitMenu.enabled = false; //exit menu is disabled
		creditMenu.enabled = false; //credit menu is disabled
		scoreMenu.enabled = false;
	
	}

	//press exit button
	public void ExitPress() {
	
		quitMenu.enabled = true; //enable exit menu
		startText.enabled = false;
		exitText.enabled = false;

	}

	//go back to main menu when no is pressed in exit menu
	public void NoPress() {

		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;

	}

	//goes to credit menu
	public void ScorePress() {
		
		scoreMenu.enabled = true;
		mainMenu.enabled = true;
		
	}

	//goes to credit menu
	public void CreditPress() {

		creditMenu.enabled = true;
		mainMenu.enabled = true;

	}

	//go back to main menu
	public void MenuPress() {

		Application.LoadLevel (0);
	
	}

	//press start game button
	public void StartLevel() {

		Application.LoadLevel (1); //loads game

	}

	//press yes to exit game
	public void ExitGame() {

		Application.Quit ();

	}

}
