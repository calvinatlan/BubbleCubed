using UnityEngine;
using System.Collections;

public class HeartControllerRainbow : MonoBehaviour {
	
	public float speed;
	private RuntimeAnimatorController rAni;
	//Color animation
	private Animator animator;


	
	void Start()
	{
		//Make bubbles move forward
		GetComponent<Rigidbody> ().velocity = transform.right * speed;

		//Load rainbow animator controller
		rAni = Resources.Load ("Master Bubble", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

	}
	void Update()
	{
		//animator = this.gameObject.AddComponent<Animator>();
		//Apply color changing animation 
		//animator.runtimeAnimatorController = rAni;
	}
}
