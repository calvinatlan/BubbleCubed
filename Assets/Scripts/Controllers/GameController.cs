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


	// bubbles
	public GameObject bubbleR;
	public GameObject bubbleG;
	public GameObject bubbleB;
	public GameObject bubbleDeath;
	public GameObject bubbleRainbow1;
	public GameObject bubbleRainbow2;
	public GameObject bubbleRainbow3;

	public float spawnWait;
	public float waveWait;
	//will tie this to speeds so that the tileing is seemless
	//private float backgroundUWait = backgroundU.z/backgroundU.speed;
	public float backgroundLWait;
	public float backgroundUWait;
	static int score = 0;
	Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
	
	void Start ()
	{
		StartCoroutine (SpawnLanes ());
		StartCoroutine (SpawnBubbles ());
//		StartCoroutine (SpawnBackgroundLower ());
//		StartCoroutine (SpawnBackgroundUpper ());
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
//	IEnumerator SpawnBackgroundLower ()
//	{
//
//		//generate first BG Lower
//		Vector3 initialPositionBGL = new Vector3 (0, -2.0f,-0.1f);
//			
//		Instantiate (backgroundL, initialPositionBGL, spawnRotation);
//
//		while (true)
//		{
//			Vector3 spawnPositionBGL = new Vector3 (0, -2.0f, backgroundLowerGenPointZ);
//			//Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
//			Instantiate (backgroundL, spawnPositionBGL, spawnRotation);
//			yield return new WaitForSeconds (backgroundLWait);
//			
//		}
//	}

//	IEnumerator SpawnBackgroundUpper ()
//	{
//		//generate first BG Upper
//		Vector3 initialPositionBGU = new Vector3 (0, -1.8f, -0.1f);
//		
//		Instantiate (backgroundL, initialPositionBGU, spawnRotation);
//
//		while (true)
//		{
//			Vector3 spawnPositionBGU = new Vector3 (0, -1.8f, backgroundUpperGenPointZ);
//			//Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
//			Instantiate (backgroundU, spawnPositionBGU, spawnRotation);
//			yield return new WaitForSeconds (backgroundUWait);
//			
//		}
//	}

	IEnumerator SpawnBubbles ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < bubbleCount; i++)
			{
				System.Random rnd = new System.Random();
				int color = rnd.Next (-1,2);
				int lane = rnd.Next (-1,2);

				if (color==-1)
				{
					System.Random chooser = new System.Random();

					Vector3 spawnPosition = new Vector3 (lane*2.5f, 0, 25);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (bubbleR, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				else if (color==0)
				{
					System.Random chooser = new System.Random();
					
					Vector3 spawnPosition = new Vector3 (lane*2.5f, 0, 25);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (bubbleG, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				if (color==1)
				{
					System.Random chooser = new System.Random();
					
					Vector3 spawnPosition = new Vector3 (lane*2.5f, 0, 25);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (bubbleB, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
			}
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
