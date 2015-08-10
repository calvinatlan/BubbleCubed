using UnityEngine;
using System.Collections;

public class ParticleRotatorRainbow : MonoBehaviour {
	
	public float rotationRadius;
	public float rotationSpeed;
	public float delay;
	public float yOffset;
	
	
	void Update() 
	{
		Transform parentLoc = gameObject.transform.parent.transform;
		float xParent = parentLoc.position.x;
		float yParent = parentLoc.position.y;
		float zParent = parentLoc.position.z;
		float xPosition = (Mathf.Sin(Time.time*rotationSpeed+ delay) * Time.deltaTime*rotationRadius) + xParent;
		float yPosition = (Mathf.Sin(Time.time*rotationSpeed+ delay) * Time.deltaTime*rotationRadius*yOffset) + yParent;
		float zPosition = (Mathf.Cos(Time.time*rotationSpeed+ delay) * Time.deltaTime*rotationRadius) + zParent;
		transform.position = new Vector3(xPosition, yPosition, zPosition);
		
	}
}