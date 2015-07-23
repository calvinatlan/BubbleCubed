using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public GameObject lane;
	public GameObject backgroundL;
	public GameObject backgroundU;

	//various floats
	public float laneWait;
	public float laneGenPointZ;
	public float backgroundUpperGenPointZ;
	public float backgroundLowerGenPointZ;
	public float startWait;
	public float bubbleCount;

	//to assimptotically approach 1, update calculation every second? 
	public static double difficulty = 0.05;

	public float spawnWait;
	public float waveWait;
	//will tie this to speeds so that the tileing is seemless
	//private float backgroundUWait = backgroundU.z/backgroundU.speed;
	public float backgroundLWait;
	public float backgroundUWait;
	//static int score = 0;
	Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);

	private BC spawner;
	
	void Start ()
	{
		spawner = GetComponent<BC>();

		StartCoroutine (SpawnLanes ());
		StartCoroutine (SpawnBubbles ());
		StartCoroutine (IncreaseDifficulty ());

	}
	
	IEnumerator SpawnLanes ()
	{
		//generate first line of lanes
		for (int i = 0; i<laneGenPointZ; i++) 
		{
			Vector3 initialPosition = new Vector3 (0, -1, i);
			//Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
			Instantiate (lane, initialPosition, spawnRotation);
		}
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (0, -1, laneGenPointZ);
			//Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
			Instantiate (lane, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (laneWait);
			
		}
	}

	IEnumerator SpawnBubbles ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			//difficulty randomizer
			System.Random rnd = new System.Random();

			int chooser = rnd.Next (1,1001);
			int color;
			if (chooser < 500- (int) difficulty * 300) color = rnd.Next (1,4);
			else if (chooser < 900) color = 4;
			else if (chooser <950- (int) difficulty * 30) color = 5;
			else if (chooser < 975- (int) difficulty * 35) color = 6;
			else if (chooser < 1000- (int) difficulty * 50)color = 7;
			else color =4;

			spawner.createBubble (color);
			yield return new WaitForSeconds (waveWait);
		}
	}

	//assymptotically increases the difficulty to 1
	IEnumerator IncreaseDifficulty ()
	{
		difficulty = 1 - ((1 - difficulty) / 1.2);
		yield return new WaitForSeconds (0.05f);
	}



}
