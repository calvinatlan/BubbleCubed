using UnityEngine;
using System.Collections;

public class BoundaryDestruction : MonoBehaviour {

	void Create(){

	}

	void Update() {

	}

	void OnTriggerEnter(Collider other){
//		print (other);
		if (other.tag == "Lane") 
		{
			other.transform.position = new Vector3(0,-1, 22.7f);
		}
		else Destroy (other.gameObject);

	}
}
