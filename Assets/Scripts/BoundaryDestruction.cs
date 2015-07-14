using UnityEngine;
using System.Collections;

public class BoundaryDestruction : MonoBehaviour {

	void Create(){

	}

	void Update() {

	}

	void OnTriggerEnter(Collider other){
		print (other);
		Destroy (other.gameObject);
	}
}
