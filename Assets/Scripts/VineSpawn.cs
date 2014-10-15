using UnityEngine;
using System.Collections;

public class VineSpawn : MonoBehaviour {
	
	public GameObject prefabVineObstacle;
	
	public float timePassed = 0;
	public float maxTimeBetweenObstacles = 120;
	public float minTimeBetweenObstacles = 90;
	public float timeBetweenObstacles;

	// Use this for initialization
	void Start () {
		timeBetweenObstacles = Random.Range (minTimeBetweenObstacles, maxTimeBetweenObstacles);
	}
	
	// Update is called once per frame
	void Update () {

		if(Camera.main.transform.position.z < 525) return;

		timePassed += Time.deltaTime;
		if(timePassed > timeBetweenObstacles) {
			GameObject obstacle = Instantiate(prefabVineObstacle) as GameObject;
			Vector3 position = obstacle.transform.position;
			position.z = Camera.main.transform.position.z + 220;
			obstacle.transform.position = position;
			timeBetweenObstacles = Random.Range (minTimeBetweenObstacles, maxTimeBetweenObstacles);
			timePassed = 0;
		}
	}
}
