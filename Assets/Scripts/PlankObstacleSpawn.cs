using UnityEngine;
using System.Collections;

public class PlankObstacleSpawn : MonoBehaviour {

	public GameObject prefabPlankObstacle;

	public float timePassed = 0;
	public float timeBetweenObstacles = 180;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Camera.main.transform.position.z < 500) return;

		timePassed += Time.deltaTime;
		if(timePassed > timeBetweenObstacles) {
			GameObject obstacle = Instantiate(prefabPlankObstacle) as GameObject;
			Vector3 position = obstacle.transform.position;
			position.z = Camera.main.transform.position.z + 220;
			obstacle.transform.position = position;
			timePassed = 0;
		}
	}
}
