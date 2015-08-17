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
			GameObject temp = GameObject.FindGameObjectWithTag ("Last Lane");
			Transform n = temp.transform;
			float nz = n.position.z;
			temp.tag = ("Lane");
			other.transform.position = new Vector3(0,-1, nz+1f);
			other.tag = ("Last Lane");
		}
		else Destroy (other.gameObject);

	}
}
