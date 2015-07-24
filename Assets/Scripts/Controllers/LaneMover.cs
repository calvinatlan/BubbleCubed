using UnityEngine;
using System.Collections;

public class LaneMover : MonoBehaviour 
{
	public float speed;
	
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.up * speed * GameController.multiplier;
	}
}
