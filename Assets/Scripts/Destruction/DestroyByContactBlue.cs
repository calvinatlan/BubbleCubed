using UnityEngine;
using System.Collections;

public class DestroyByContactBlue : MonoBehaviour {

	public GameObject explosionG;
	public GameObject explosionR;



	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Blue Bubble") 
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			Destroy (other.gameObject);
			this.transform.parent.GetComponent<Player>().counts++;
			this.transform.parent.GetComponent<Player>().health+=3;//here
		}
		else if (other.tag == "Green Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().health-=5;//here
			this.transform.parent.GetComponent<Player>().counts = 0;
			Instantiate(explosionG, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		else if (other.tag == "Red Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().health-=5;//here
			this.transform.parent.GetComponent<Player>().counts = 0;
			Instantiate(explosionR, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
	}
}
