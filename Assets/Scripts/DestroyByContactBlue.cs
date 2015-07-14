using UnityEngine;
using System.Collections;

public class DestroyByContactBlue : MonoBehaviour {

	public GameObject explosionG;
	public GameObject explosionR;



	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Blue Bubble") 
		{
			Destroy (other.gameObject);
			this.transform.parent.GetComponent<Player>().count++;
		}
		else if (other.tag == "Green Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().count = 0;
			Instantiate(explosionG, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		else if (other.tag == "Red Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().count = 0;
			Instantiate(explosionR, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
	}
}
