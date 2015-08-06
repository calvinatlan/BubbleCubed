using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (2, 2, 2) * Time.deltaTime);
	}
}
