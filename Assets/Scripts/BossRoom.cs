using UnityEngine;
using System.Collections;

public class BossRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z < Camera.main.transform.position.z - 60) {
			foreach(Transform child in transform) {
				Destroy(child.gameObject);
			}
		}
	}
}
