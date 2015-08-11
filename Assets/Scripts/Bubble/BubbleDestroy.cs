using UnityEngine;
using System.Collections;

public class BubbleDestroy : MonoBehaviour {
	
	void OnEnable(){
		Invoke("Destroy", 1f);
	}
	
	void Destroy(){
		gameObject.SetActive(false);
	}
	
	void OnDisable(){
		CancelInvoke();
	}
	
}
