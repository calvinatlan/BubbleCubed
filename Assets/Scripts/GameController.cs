using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public GameObject lane;
	public float laneWait;
	public float laneGenPointZ;
	public float startWait;
	public float bubbleCount;
	public GameObject bubbleR;
	public GameObject bubbleG;
	public GameObject bubbleB;
	public float spawnWait;
	public float waveWait;
	static int score = 0;
	
	void Start ()
	{
		StartCoroutine (SpawnLanes ());
		StartCoroutine (SpawnBubbles ());
	}
	
	IEnumerator SpawnLanes ()
	{
		//generate first line of lanes
		for (int i = 0; i<laneGenPointZ; i++) 
		{
			Vector3 initialPosition = new Vector3 (0, -1, i);
			Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
			Instantiate (lane, initialPosition, spawnRotation);
		}
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (0, -1, laneGenPointZ);
			Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
			Instantiate (lane, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (laneWait);
			
		}
	}

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

}
