using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;
	
	List<GameObject> pooledObjects;


	void Awake(){
		current = this;
	}


	void Start () {
		pooledObjects = new List<GameObject> ();
		for(int i = 0; i < pooledAmount; i++){
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}

	}

	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++) {
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}
		//if allowed to grow, instantiate another object and use it
		if (willGrow) {
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
			return obj;
		}
		//if not allowed to grow return null
		return null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
