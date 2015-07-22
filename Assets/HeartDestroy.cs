using UnityEngine;
using System.Collections;

public class HeartDestroy : MonoBehaviour {
	
	//public GameObject explosionHeart;

	
	
	
	void OnTriggerEnter(Collider other) 
	{

			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Destroy (other.gameObject);
			this.transform.parent.GetComponent<Player>().counts++;
			this.transform.parent.GetComponent<Player>().totalCount++;
			this.transform.parent.GetComponent<Player>().health+=25;//here


	}
}
