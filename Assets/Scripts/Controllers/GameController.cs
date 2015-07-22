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
	static private float difficulty = 0;

	public float spawnWait;
	public float waveWait;
	//will tie this to speeds so that the tileing is seemless
	//private float backgroundUWait = backgroundU.z/backgroundU.speed;
	public float backgroundLWait;
	public float backgroundUWait;
	static int score = 0;
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
			System.Random rnd = new System.Random();
			/*
			int color = rnd.Next (-1,2);
			int lane = rnd.Next (-1,2);

			if (color==-1)
			{
				spawner.createBubble (1);
			}
			else if (color==0)
			{
				spawner.createBubble(2);
			}
			if (color==1)
			{
				spawner.createBubble(3);
			}
			*/
			int color = rnd.Next (1,6);
			spawner.createBubble (color);
			yield return new WaitForSeconds (waveWait);
		}
	}

	//assymptotically increases the difficulty to 1
	IEnumerator IncreaseDifficulty ()
	{

		//get game time
		yield return new WaitForSeconds (1);
	}

}
