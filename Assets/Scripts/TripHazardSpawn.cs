using UnityEngine;
using System.Collections;

public class TripHazardSpawn : MonoBehaviour {
	
	public GameObject prefabTripHazard;
	
	public float timePassed = 0;
	public float maxTimeBetweenHazards = 30;
	public float minTimeBetweenHazards = 45;
	public float timeBetweenHazards;

	// Use this for initialization
	void Start () {
		timeBetweenHazards = Random.Range (minTimeBetweenHazards, maxTimeBetweenHazards);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Camera.main.transform.position.z < 550) return;
		
		timePassed += Time.deltaTime;
		if(timePassed > timeBetweenHazards) {
			GameObject obstacle = Instantiate(prefabTripHazard) as GameObject;
			Vector3 position = obstacle.transform.position;
			position.z = Camera.main.transform.position.z + 220;
			obstacle.transform.position = position;
			timeBetweenHazards = Random.Range (minTimeBetweenHazards, maxTimeBetweenHazards);
			timePassed = 0;
		}

	}
}
