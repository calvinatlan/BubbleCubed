using UnityEngine;
using System.Collections;

public class DestroyByContactRed : MonoBehaviour 
{
	public GameObject explosionB;
	public GameObject explosionG;

	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Red Bubble") 
		{
			Destroy (other.gameObject);
		}
		else if (other.tag == "Blue Bubble" ) 
		{
			Instantiate(explosionB, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		else if (other.tag == "Green Bubble" ) 
		{
			Instantiate(explosionG, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
	}
}
