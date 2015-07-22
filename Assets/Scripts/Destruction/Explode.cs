using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour{

	//Explosion prefab
	public GameObject explosion;

	//Color materials
	private Material[] mat = new Material[10];

	void Start(){
		//Load color materials	
		mat [1] = Resources.Load ("Red", typeof(Material)) as Material;
		mat [2] = Resources.Load ("Green", typeof(Material)) as Material;
		mat [3] = Resources.Load ("Blue", typeof(Material)) as Material;
	}

	public void sd(){
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

	
}
