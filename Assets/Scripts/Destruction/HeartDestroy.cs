using UnityEngine;
using System.Collections;

public class HeartDestroy : MonoBehaviour {
	
	private GameObject explosionHeart;
	private Material[] mat = new Material[10];

	private GameObject cube;
	private Player player;

	void Start ()
	{
		cube = GameObject.FindGameObjectWithTag ("Player");
		player = cube.GetComponent<Player> ();
		explosionHeart = (GameObject)Resources.Load ("Heart Explosion");

	}
	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Player") 
		{
			player.healthPoints(25);
			player.addPoints(100);
			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Destroy (other.gameObject);
			//this.transform.parent.GetComponent<Player> ().counts++;
			//this.transform.parent.GetComponent<Player> ().totalCount++;
			//this.transform.parent.GetComponent<Player> ().health += 25;//here
			Instantiate (explosionHeart, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
