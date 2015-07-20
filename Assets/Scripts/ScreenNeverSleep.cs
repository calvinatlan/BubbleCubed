using UnityEngine;
using System.Collections;

public class ScreenNeverSleep : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
