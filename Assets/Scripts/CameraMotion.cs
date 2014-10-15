using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerMove.speed > 0){
			Vector3 position = Camera.main.transform.position;
			position.y += .025f * Mathf.Sin(Time.time * 6f * Mathf.PI);
			Camera.main.transform.position = position;
		}
	
	}
}
