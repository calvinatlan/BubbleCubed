using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	public float rotationRadius;
	public float rotationSpeed;
	public float delay;
	

	void Update() 
	{
		Transform parentLoc = gameObject.transform.parent.transform;
		float xParent = parentLoc.position.x;
		float zParent = parentLoc.position.z;
		float xPosition = (Mathf.Sin(Time.time*rotationSpeed+ delay) * Time.deltaTime*rotationRadius) + xParent;
		float zPosition = (Mathf.Cos(Time.time*rotationSpeed+ delay) * Time.deltaTime*rotationRadius) + zParent;
		transform.position = new Vector3(xPosition, 0, zPosition);

	}
}