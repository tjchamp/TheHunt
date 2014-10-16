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

		if(Time.timeSinceLevelLoad > 11f) {

			int i = 0;
			int bulletCount = GameObject.Find ("Player").GetComponent<PlayerMove>().bulletCount;
			
			foreach(Transform child in transform){
				if(i++ == bulletCount) break;
				Vector3 v3Pos; 
				v3Pos.x = 0.85f + 0.0675f * Mathf.Cos(i * Mathf.PI/3);
				v3Pos.y = 0.15f + 0.0875f * Mathf.Sin(i * Mathf.PI/3); 
				v3Pos.z = 2.5f;
				child.transform.position = Camera.main.camera.ViewportToWorldPoint(v3Pos);
				child.renderer.enabled = true;
			}

		}
	
	}
}
