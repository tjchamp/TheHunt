using UnityEngine;
using System.Collections;

public class orient_bullets : MonoBehaviour {

	public float t = 0;

	// Use this for initialization
	void Start () {
		transform.renderer.enabled = false;
		transform.LookAt (Camera.main.transform);
		foreach(Transform child in transform){
			child.renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > 11f){
			transform.LookAt (Camera.main.transform);
			foreach(Transform child in transform){
				child.renderer.enabled = true;
			}
		}
	
	}
}
