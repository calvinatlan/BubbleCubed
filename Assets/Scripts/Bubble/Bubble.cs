using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour 
{

	//---------------------------Variables---------------------------//
	//---------------------------------------------------------------//

	public float speed;
	public float points;

	//Gamestate manipulation
	private GameObject cube;
	private Player player;
	private Explode explode;

	//Bubble materials
	private Material[] bMat = new Material[10];

	//Color animation
	private Animator animator;
	private RuntimeAnimatorController rAni;

	//All possible bubbles
	public enum colors {RED = 1, GREEN = 2, BLUE = 3, HAZARD = 4, RAINBOW = 5};

	//Red:1,Blue:2,Green:3,Death:4,Powerup,5+
	private colors color = 0;
	private colors prevColor = 0;
	
	//---------------------------------------------------------------//
	//---------------------------------------------------------------//

	//---------------------MonoBehavior Functions---------------------//
	//---------------------------------------------------------------//
	void Start ()
	{
		//Load bubble materials
		bMat[1] = Resources.Load("RedBubble", typeof(Material)) as Material;
		bMat[2] = Resources.Load("GreenBubble", typeof(Material)) as Material;
		bMat[3] = Resources.Load("BlueBubble", typeof(Material)) as Material;
		bMat[4] = Resources.Load("HazardBubble", typeof(Material)) as Material;
		bMat[5] = Resources.Load("RainbowBubble", typeof(Material)) as Material;

		//Load rainbow animator controller
		rAni = Resources.Load ("Master Bubble",typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

		//Load scripts
		cube = GameObject.FindGameObjectWithTag ("Player");
		player = cube.GetComponent<Player> ();
		explode = gameObject.GetComponent<Explode> ();


	}

	void Update(){

		//Make bubbles move forward
		GetComponent<Rigidbody>().velocity = transform.forward * speed * GameController.multiplier;

		//Change material if color changed
		if(color != prevColor){
			prevColor = color;
			GetComponent<Renderer>().material = bMat[(int)color];
		}

		//Set animator if bubble is rainbow
		if(color == colors.RAINBOW){

			//Create animator if there isn't one
			if(GetComponent<Animator>() == null){
				animator = this.gameObject.AddComponent<Animator>();
			}else{
				animator = this.gameObject.GetComponent<Animator>();
			}

			//Apply color changing animation 
			animator.runtimeAnimatorController = rAni;
		}
	}

	void OnTriggerEnter(Collider other){


		Renderer otherR = other.gameObject.GetComponent<Renderer> ();
		if (player.getRainbow())
		{
			Destroy (this.gameObject);
			player.healthPoints(3);
			player.addPoints(10);
		}
		else if (otherR != null) {
			//If it does, it checks the name and compares it to the color of this bubble
			string otherS = otherR.material.name.ToUpper ();

			//make sure it matches at least 1 enum, otherwise, don't destroy bubble
			bool isColored = false;
			foreach(var i in System.Enum.GetValues(typeof(colors))){
				if (otherS.StartsWith (i.ToString())){
					isColored = true;
				}
			}
			//Destroy object and do score things if it's true
			if (isColored == true){
				Destroy (this.gameObject);
				if(otherS.StartsWith (color.ToString())){
					player.healthPoints(3);
					player.addPoints(10);
					explode.sd ("good");
				}else if(color==colors.RAINBOW){
					StartCoroutine (player.turnToRainbow());
					player.notificationFunc("RAINBOW!!!");
				}
				else {
					player.hurt(5);
					explode.sd("bad");
				}
			}

		}
	}
	
	//---------------------------------------------------------------//
	//---------------------------------------------------------------//


	//-----------------------Color management-----------------------//
	//--------------------------------------------------------------//

	//getter and overloaded setter for the color of the bubble, 
	//if you need to change it post creation for whatever reason
	public void setColor(int x){
		color = (colors) x;
	}

	public void setColor(string x){
//		color = (colors)enum.pa	
	}

	public colors getColor(){
		return color;
	}
	
	//--------------------------------------------------------------//
	//--------------------------------------------------------------//




}
