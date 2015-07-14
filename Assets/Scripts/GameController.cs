using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject lane;
	public float laneWait;
	public float laneGenPointZ;
	
	void Start ()
	{
		StartCoroutine (SpawnLanes ());
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

}
