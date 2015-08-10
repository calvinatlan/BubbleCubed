using UnityEngine;
using System.Collections;

public class HeartDestroyRainbow : MonoBehaviour {
	
	private GameObject explosionRainbowHeart;
	
	private GameObject cube;
	private Player player;
	
	void Start ()
	{
		cube = GameObject.FindGameObjectWithTag ("Player");
		player = cube.GetComponent<Player> ();
		explosionRainbowHeart = (GameObject)Resources.Load ("Rainbow Heart Explosion");
		
	}
	void OnTriggerEnter(Collider other) 
	{
		
		if (other.tag == "Player") 
		{
			player.startHealthUp();
			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Destroy (other.gameObject);
			//this.transform.parent.GetComponent<Player> ().counts++;
			//this.transform.parent.GetComponent<Player> ().totalCount++;
			//this.transform.parent.GetComponent<Player> ().health += 25;//here

			Instantiate (explosionRainbowHeart, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
		
		
	}
}
