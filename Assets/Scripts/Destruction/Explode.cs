using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour{

	//Explosion prefab
	public GameObject badExplosion;

	public GameObject goodExplosion;

	//Color materials
	private Material[] mat = new Material[10];

	void Start(){
		//Load color materials	
		//mat [1] = Resources.Load ("Red", typeof(Material)) as Material;
		//mat [2] = Resources.Load ("Green", typeof(Material)) as Material;
		//mat [3] = Resources.Load ("Blue", typeof(Material)) as Material;
		//mat [4] = Resources.Load ("White", typeof(Material)) as Material;
	}

	public void sd(string s){
		if (s.Contains("bad")) {
			Instantiate (badExplosion, transform.position, transform.rotation);
		} else if (s.Contains("good")) {
			Instantiate (goodExplosion, transform.position, transform.rotation);
		}
		Destroy (this.gameObject);
	}
}
