using UnityEngine;
using System.Collections;

public class HeartControllerRainbow : MonoBehaviour {
	
	public float speed;
	private RuntimeAnimatorController rAni;
	//Color animation
	private Animator animator;


	
	void Start()
	{


		//Load rainbow animator controller
		rAni = Resources.Load ("Master Bubble", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

	}
	void Update()
	{
		//Make bubbles move forward
		GetComponent<Rigidbody> ().velocity = transform.right * speed * GameController.multiplier;
	}
}
