using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject lane;
	public float laneWait;
	
	void Start ()
	{
		StartCoroutine (SpawnLanes ());
	}
	
	IEnumerator SpawnLanes ()
	{
		
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (0, -1, 10);
			Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(90f,0f,0f);
			Instantiate (lane, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (laneWait);
			
		}
	}

}
