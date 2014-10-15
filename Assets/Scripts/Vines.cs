using UnityEngine;
using System.Collections;

public class Vines : MonoBehaviour {

	public int health = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F) && Mathf.Abs(transform.position.z - Camera.main.transform.position.z) < 5) {
			health--;
		}
		if(health <= 0) {
			PlayerMove.speed = 10;
			Destroy(this.gameObject);
		}
		if(transform.position.z < Camera.main.transform.position.z - 60)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>())
			PlayerMove.speed = 3;
		else if(col.GetComponent<BossRoom>()) 
			Destroy(this.gameObject);
	}

	void OnTriggerStay(Collider col) {
		OnTriggerEnter(col);
	}

	void OnTriggerExit(Collider col) {
		if(col.GetComponent<PlayerMove>()) 
			PlayerMove.speed = 10;
	}
}
