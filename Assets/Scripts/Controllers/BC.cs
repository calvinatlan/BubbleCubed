﻿using UnityEngine;
using System;
using System.Collections;

public class BC : MonoBehaviour {

	public GameObject bubble;
	public GameObject heart;
	public GameObject heartRain;

	public GameObject rainbowHalo;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp ("5")) { 
			createBubble (5);
		}
		if (Input.GetKeyUp ("6")) {
			createBubble (6);
		}
		if (Input.GetKeyUp	("7")) {
			createBubble (7);
		}
	}

	public void createBubble(){
		System.Random rand = new System.Random ();
		Vector3 spawnPosition = new Vector3 (rand.Next(-1,2)*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject bub = (GameObject) Instantiate (bubble, spawnPosition, spawnRotation);
		bub.GetComponent<Bubble>().setColor(1);
	}

	public void createBubble(int x){
		System.Random rand = new System.Random ();
		int lane = rand.Next (-1, 2);
		int otherLane = rand.Next (-1, 2);
		while (otherLane==lane) 
		{
			otherLane = rand.Next (-1, 2);
		}
		Vector3 spawnPosition = new Vector3 (lane*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		if (x == 5) 
		{
			Quaternion spawnRotation2 = Quaternion.identity * Quaternion.Euler (0f, 90f, 90f);
			GameObject panel1 = (GameObject)Instantiate (rainbowHalo, spawnPosition, spawnRotation2);

			
		} 
		if (x == 6) 
		{
			Quaternion spawnRotation2 = Quaternion.identity * Quaternion.Euler (-90f, -90f, 0f);
			GameObject hrt = (GameObject)Instantiate (heart, spawnPosition, spawnRotation2);

		} 
		else if (x == 7) 
		{
			Quaternion spawnRotation2 = Quaternion.identity * Quaternion.Euler (-90f, -90f, 0f);
			GameObject hrtR = (GameObject)Instantiate (heartRain, spawnPosition, spawnRotation2);
			
		} 
		else 
		{
			
			GameObject bub = (GameObject)Instantiate (bubble, spawnPosition, spawnRotation);
			bub.GetComponent<Bubble> ().setColor (x);
			gameObject.tag = "Bubble";

		}


		double bar =  rand.NextDouble();
		if (bar < GameController.difficulty) 
		{
			Vector3 spawnPosition2 = new Vector3 (otherLane * 2.5f, 0, 25);
			GameObject bub2 = (GameObject)Instantiate (bubble, spawnPosition2, spawnRotation);
			bub2.GetComponent<Bubble> ().setColor (4);
		}
	}

	public void createBubble(int x, int y){
	//	System.Random rand = new System.Random ();
		Vector3 spawnPosition = new Vector3 (y*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject bub = (GameObject) Instantiate (bubble, spawnPosition, spawnRotation);
		bub.GetComponent<Bubble>().setColor(x);
	}
}
