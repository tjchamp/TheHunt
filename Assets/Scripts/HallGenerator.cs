using UnityEngine;
using System.Collections;

public class HallGenerator : MonoBehaviour {

	const float hallLength = 220f;
	const float wallLength = 10f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// If the Hall Block is behind the player, move it to the end of the hall.
		if(transform.position.z < Camera.main.transform.position.z - 210)
		{
			// Move the Hall Block to the end of the hall.
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Floor(newPos.z + 2*hallLength-10);
			newPos.y = transform.position.y;
			transform.position = newPos;

			// Move the back to be at the new and of the hall.
			
		}
		GameObject farWall = GameObject.Find("FarWall");
		Vector3 newFarWallPos = farWall.transform.position;
		newFarWallPos.z = Camera.main.transform.position.z + 190;
		farWall.transform.position = newFarWallPos;
		
		GameObject backWall = GameObject.Find ("BackWall");
		Vector3 newBackWallPos = backWall.transform.position;
		newBackWallPos.z = Camera.main.transform.position.z - 190;
		backWall.transform.position = newBackWallPos;
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<BossRoom>()) {
			foreach(Transform child in transform)
				child.renderer.enabled = false;
		}
	}
	
	void OnTriggerExit(Collider col) {
		if(col.GetComponent<BossRoom>()) {
			foreach(Transform child in transform)
				child.renderer.enabled = true;
		}
	}
}
