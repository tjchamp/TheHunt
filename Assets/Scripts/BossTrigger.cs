using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {

	public GameObject minionSpawner;
	public GameObject ObstacleSpawner;
	public GameObject tripSpawner;
	public GameObject vineSpawner;
	public GameObject [] minions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>())
		{
			PlayerMove.speed = 0;
			minionSpawner.GetComponent<SmallEnemySpawn>().enabled = false;
			ObstacleSpawner.GetComponent<PlankObstacleSpawn>().enabled = false;
			tripSpawner.GetComponent<TripHazardSpawn>().enabled = false;
			vineSpawner.GetComponent<VineSpawn>().enabled = false;
			Destroy(gameObject);
			col.GetComponent<PlayerMove>().boss = true;
			GameObject light = GameObject.Find("PlayerLight");
			light.GetComponent<Light>().range = 45;
			minions = GameObject.FindGameObjectsWithTag("Minion");
			foreach(GameObject minion in minions) Destroy(minion.gameObject);
		}
	}
	
}
