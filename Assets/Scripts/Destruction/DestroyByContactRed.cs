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
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			Destroy (other.gameObject);
			this.transform.parent.GetComponent<Player>().counts++;
			this.transform.parent.GetComponent<Player>().totalCount++;
			this.transform.parent.GetComponent<Player>().health+=3;//here
		}
		else if (other.tag == "Blue Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().counts = 0;
			this.transform.parent.GetComponent<Player>().totalWrong++;
			this.transform.parent.GetComponent<Player>().health-=5;//here
			Instantiate(explosionB, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		else if (other.tag == "Green Bubble" ) 
		{
			this.transform.parent.GetComponent<Player>().counts = 0;
			this.transform.parent.GetComponent<Player>().totalWrong++;
			this.transform.parent.GetComponent<Player>().health-=5;//here
			Instantiate(explosionG, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
	}
}
