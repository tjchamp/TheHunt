using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	
	public GameObject minionSpawner;
	public GameObject ObstacleSpawner;
	public GameObject tripSpawner;
	public GameObject vineSpawner;
	public GameObject hoard_spawn;

	public bool activated = false;
	public bool inPlace = false;
	public GameObject [] minions;

	public float rotationAngle = 20;
	public float maxRotation = 90;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(activated) {
			GameObject.Find("Player").GetComponent<PlayerMove>().canPull = true;
			transform.Rotate(Vector3.down, rotationAngle * Time.deltaTime);
			if(transform.localEulerAngles.x >= maxRotation) {
				
				activated = false;
				PlayerMove.speed = 10;
				GameObject.Find("Player").GetComponent<PlayerMove>().boss = false;
				GameObject.Find("Player").GetComponent<PlayerMove>().canPull = false;
				minionSpawner.GetComponent<SmallEnemySpawn>().enabled = true;
				ObstacleSpawner.GetComponent<PlankObstacleSpawn>().enabled = true;
				tripSpawner.GetComponent<TripHazardSpawn>().enabled = true;
				vineSpawner.GetComponent<VineSpawn>().enabled = true;
				GameObject light = GameObject.Find("PlayerLight");
				light.GetComponent<Light>().range = 100;
				inPlace = true;
				hoard_spawn.GetComponent<hoard_spawn>().spawning = false;
				minions = GameObject.FindGameObjectsWithTag("Minion");
				foreach(GameObject minion in minions) Destroy(minion.gameObject);
			}
		}
	}
}
