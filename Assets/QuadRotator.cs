using UnityEngine;
using System.Collections;

public class QuadRotator : MonoBehaviour {

	public float rotationSpeed;


	
	void Update ()
	{
		Transform parentLoc = gameObject.transform.parent.transform;
		float xParent = parentLoc.position.x;
		float yParent = parentLoc.position.y;
		float zParent = parentLoc.position.z;
		transform.position = new Vector3(xParent, yParent, zParent);
		transform.Rotate (new Vector3 (0, 0, 30) * Time.deltaTime* rotationSpeed);


	}
}
