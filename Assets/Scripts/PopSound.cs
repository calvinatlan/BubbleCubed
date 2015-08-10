using UnityEngine;
using System.Collections;

public class PopSound : MonoBehaviour {

	private AudioSource sE;
	public AudioClip [] pop = new AudioClip[5];
	public float seVolume;
	// Use this for initialization
	void Start () {
		sE = gameObject.AddComponent<AudioSource>();
		sE.clip = pop [Random.Range(0, 4)];
		sE.volume = seVolume;
		sE.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
