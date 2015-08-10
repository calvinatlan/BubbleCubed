using UnityEngine;
using System.Collections;

public class LaneMover : MonoBehaviour 
{
	public float speed;
	
	void Update ()
	{
		GetComponent<Rigidbody>().velocity = transform.up * speed * GameController.multiplier;
	}
}
