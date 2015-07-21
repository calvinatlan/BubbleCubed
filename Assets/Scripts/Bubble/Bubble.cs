using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour 
{
	public float speed;

	//Materials
	private Material[] mat = new Material[10];
	private Animator animator;
	private RuntimeAnimatorController rAni;

	public enum colors {RED = 1, BLUE = 2, GREEN = 3, RAINBOW = 5};

	//Red:1,Blue:2,Green:3,Death:4,Powerup,5+
	private colors color = 0;
	private colors prevColor = 0;

	void Start ()
	{
		//Load materials
		mat[1] = Resources.Load("RedBubble", typeof(Material)) as Material;
		mat[2] = Resources.Load("GreenBubble", typeof(Material)) as Material;
		mat[3] = Resources.Load("BlueBubble", typeof(Material)) as Material;
		mat[5] = Resources.Load("RainbowBubble", typeof(Material)) as Material;

		//Load rainbow animator controller
		rAni = Resources.Load ("Master Bubble",typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Update(){

		//Change material if color changed
		if(color != prevColor){
			prevColor = color;
			GetComponent<Renderer>().material = mat[(int)color];
		}

		//Set animator if bubble is rainbow
		if(color == colors.RAINBOW){

			//Create animator if there isn't one, and make it the rainbow
			if(GetComponent<Animator>() == null){
				animator = this.gameObject.AddComponent<Animator>();
			}else{
				animator = this.gameObject.GetComponent<Animator>();
			}
			animator.runtimeAnimatorController = rAni;
		}
	}

	public void setColor(int x){
		color = (colors) x;
	}

	public colors getColor(){
		return color;
	}

	public void setColor(string x){
//		color = (colors)enum.pa	
	}



}
