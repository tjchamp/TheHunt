using UnityEngine;
using System.Collections;

public class PlankObstacle : MonoBehaviour {

	public int health = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z < Camera.main.transform.position.z - 10)
			Destroy(gameObject);


		bool allFlawsShot = true;
		foreach(Transform child in transform)
		{
			if(child.tag == "Flaw")
				allFlawsShot = false;
		}

		if(Input.GetKeyDown(KeyCode.F) && allFlawsShot) {
			health -= 1;
			if(health % 5 == 0)
			{
				foreach(Transform child in transform) {
					if(child.transform.tag == "Plank"){
						Destroy(child.gameObject);
						break;
					}
				}
			}
		} if(health == 0) {
			Destroy(gameObject);
			PlayerMove.speed = 10;
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>()) {
			PlayerMove.speed = 0;
		} else if(col.GetComponent<Vines>() || col.GetComponent<BossRoom>()) 
			Destroy(this.gameObject);
	}
}
