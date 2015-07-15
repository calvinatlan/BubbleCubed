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
			this.transform.parent.GetComponent<Player>().count++;//here
		}

		else if (other.tag == "Blue Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().count = 0;
			Instantiate(explosionB, other.transform.position, other.transform.rotation);//here
			Destroy (other.gameObject);
		}
		else if (other.tag == "Red Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().count = 0;
			Instantiate(explosionR, other.transform.position, other.transform.rotation);//here
			Destroy (other.gameObject);
		}

	}
}
