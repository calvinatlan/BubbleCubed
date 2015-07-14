using UnityEngine;
using System.Collections;

public class DestroyByContactRed : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Red Bubble") 
		{
			Destroy (other.gameObject);
		}
	}
}
