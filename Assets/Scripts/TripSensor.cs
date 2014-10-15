using UnityEngine;
using System.Collections;

public class TripSensor : MonoBehaviour {

	public float timePassed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if(timePassed >= 10)
		{
			Destroy(GetComponent<SphereCollider>());
			Destroy(GetComponent<Rigidbody>());
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<Vines>() || col.GetComponent<PlankObstacle>()) {
			if(Random.Range(0, 2) < 1)
				Destroy(gameObject);
			else
				Destroy(col.gameObject);
		}
		if(col.GetComponent<BossRoom>())
			Destroy(gameObject);
	}
}
