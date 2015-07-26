using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

	public float speed;

	void Update()
	{
		//Make bubbles move forward
		GetComponent<Rigidbody> ().velocity = transform.right * speed * GameController.multiplier;
	}
}
