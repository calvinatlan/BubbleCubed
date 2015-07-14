using UnityEngine;
using System.Collections;

public class BubbleMover : MonoBehaviour 
{
	public float speed;
	
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
