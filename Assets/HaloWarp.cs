using UnityEngine;
using System.Collections;

public class HaloWarp : MonoBehaviour {

	private Vector3 scaleS;
	private Vector3 scaleL;
	private Vector3 rStart;
	private Vector3 mini;


	void LateUpdate ()
	{
		//GetComponent<Halo>().size = 4;
		transform.GetComponent<Light>().intensity = Mathf.Abs(Mathf.Sin(Time.time));
	}
}
