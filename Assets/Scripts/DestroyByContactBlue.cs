using UnityEngine;
using System.Collections;

public class DestroyByContactBlue : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Blue Bubble") 
		{
			Destroy (other.gameObject);
		}
	}
}
