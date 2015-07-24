using UnityEngine;
using System.Collections;

public class HeartDestroy : MonoBehaviour {
	
	//public GameObject explosionHeart;

	private GameObject cube;
	private Player player;

	void Start ()
	{
		cube = GameObject.FindGameObjectWithTag ("Player");
		player = cube.GetComponent<Player> ();

	}
	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Player") 
		{
			player.healthPoints(25);
			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Destroy (other.gameObject);
			//this.transform.parent.GetComponent<Player> ().counts++;
			//this.transform.parent.GetComponent<Player> ().totalCount++;
			//this.transform.parent.GetComponent<Player> ().health += 25;//here

			Destroy(this.gameObject);
		}


	}
}
