using UnityEngine;
using System.Collections;

public class HaloMover : MonoBehaviour {

	public float speed;
	// Update is called once per frame
	void Update () {
	
		GetComponent<Rigidbody>().velocity = transform.up * speed * GameController.multiplier;
	}
	void OnTriggerEnter(Collider other){
		//		print (other);
		if (other.tag == "Player") 
		 Destroy (gameObject);
		
	}
}
