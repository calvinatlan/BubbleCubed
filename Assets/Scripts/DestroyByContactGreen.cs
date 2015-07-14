using UnityEngine;
using System.Collections;

public class DestroyByContactGreen : MonoBehaviour {

	public GameObject explosionB;
	public GameObject explosionR;

	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Green Bubble") 
		{
			Destroy (other.gameObject);

		}

		else if (other.tag == "Blue Bubble" ) 
		{
			Instantiate(explosionB, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		else if (other.tag == "Red Bubble" ) 
		{
			Instantiate(explosionR, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}

	}
}
