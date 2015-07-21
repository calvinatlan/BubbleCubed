using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour 
{
	public float speed;

	//Materials
	private Material rMat;
	public Material bMat;
	public Material gMat;

	public enum colors {RED = 1, BLUE = 2, GREEN = 3};

	//Red:1,Blue:2,Green:3,Death:4,Powerup,5+
	private colors color = 0;
	private colors prevColor = 0;

	void Start ()
	{
		rMat = Resources.Load("RedBubble", typeof(Material)) as Material;
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Update(){
		if(color != prevColor){
			prevColor = color;
			GetComponent<Renderer>().material = rMat;
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
