﻿using UnityEngine;
using System.Collections;

public class BC : MonoBehaviour {

	public GameObject bubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp	("space")) {
			Debug.Log("space");
			createBubble ();
		}
	}

	public void createBubble(){
		System.Random rand = new System.Random ();
		Vector3 spawnPosition = new Vector3 (rand.Next(-1,2)*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bubble, spawnPosition, spawnRotation);
	}

	public void createBubble(int x){
		System.Random rand = new System.Random ();
		Vector3 spawnPosition = new Vector3 (rand.Next(-1,2)*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bubble, spawnPosition, spawnRotation);
	}

	public void createBubble(int x, int y){
		System.Random rand = new System.Random ();
		Vector3 spawnPosition = new Vector3 (y*2.5f, 0, 25);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bubble, spawnPosition, spawnRotation);
	}
}