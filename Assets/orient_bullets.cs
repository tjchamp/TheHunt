using UnityEngine;
using System.Collections;


public class orient_bullets : MonoBehaviour {

	public GameObject[] bullets;

	public float t = 0;

	// Use this for initialization
	void Start () {
		//transform.LookAt (Camera.main.transform);
		foreach(Transform child in transform){
			child.renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > 11f){
			//transform.LookAt (Camera.main.transform);

			int bulletShowIndex = 0;
			int bulletCount = GameObject.Find ("Player").GetComponent<PlayerMove>().bulletCount;

			foreach(Transform child in transform){
				if(bulletShowIndex++ == bulletCount) break;
				child.renderer.enabled = true;
			}
		}
	
	}
}
