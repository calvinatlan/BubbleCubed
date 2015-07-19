using UnityEngine;
using System.Collections;

public class DestroyByContactGreen : MonoBehaviour {

	public GameObject explosionB;
	public GameObject explosionR;

	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Green Bubble") 
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			Destroy (other.gameObject);
			this.transform.parent.GetComponent<Player>().counts++;//here
			this.transform.parent.GetComponent<Player>().health+=3;//here
		}

		else if (other.tag == "Blue Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().counts = 0;
			this.transform.parent.GetComponent<Player>().health-=5;//here
			Instantiate(explosionB, other.transform.position, other.transform.rotation);//here
			Destroy (other.gameObject);
		}
		else if (other.tag == "Red Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().health-=5;//here
			this.transform.parent.GetComponent<Player>().counts = 0;
			Instantiate(explosionR, other.transform.position, other.transform.rotation);//here
			Destroy (other.gameObject);
		}

	}
}
