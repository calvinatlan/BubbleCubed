using UnityEngine;
using System.Collections;

public class DestroyByContactGreen : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Green Bubble") 
		{
			Destroy (other.gameObject);

		}
	}
}
