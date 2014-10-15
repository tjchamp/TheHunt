using UnityEngine;
using System.Collections;

public class TripHazard : MonoBehaviour {

	public bool tripped;
	public float minSpeed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tripped)
		{
			PlayerMove.speed = Mathf.Min(PlayerMove.speed + 5 * Time.deltaTime, 10);
			if(PlayerMove.speed == 10)
				Destroy(gameObject);
		}
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>()) {
			if(Mathf.Abs(col.transform.position.z - transform.position.z) < 1f) {
				tripped = true;
				PlayerMove.speed = minSpeed;
			}
		}
	}

	void OnTriggerStay(Collider col) {
		OnTriggerEnter(col);
	}
}
