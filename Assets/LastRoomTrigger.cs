using UnityEngine;
using System.Collections;

public class LastRoomTrigger : MonoBehaviour {

		
	public GameObject minionSpawner;
	public GameObject ObstacleSpawner;
	public GameObject monster;
	public GameObject [] minions;
	public bool lightsOut;
	public float t = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lightsOut){
			Vector3 position = Camera.main.transform.position;
			position.y += .05f * Mathf.Sin(Time.time * 3f * Mathf.PI);
			Camera.main.transform.position = position;
			t += Time.deltaTime;
			if(t > 2){
				GameObject light = GameObject.Find("PlayerLight");
				Destroy(light.GetComponent<FlickeringLight>());
				light.GetComponent<Light>().intensity = Mathf.Lerp (light.GetComponent<Light>().intensity, .1f, .5f*Time.deltaTime);
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.back), 10*Time.deltaTime);
			}
			if(t > 10){
				monster.SetActive (true);
				monster.GetComponent<MonsterFollow>().lastRoom = true;
				Destroy (this.gameObject);
			}
		}
		
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>())
		{
			PlayerMove.speed = 0;
			col.GetComponent<PlayerMove>().lastRoom = true;
			minionSpawner.GetComponent<SmallEnemySpawn>().enabled = false;
			ObstacleSpawner.GetComponent<PlankObstacleSpawn>().enabled = false;
			
			lightsOut = true;
			minions = GameObject.FindGameObjectsWithTag("Minion");
			foreach(GameObject minion in minions) Destroy(minion.gameObject);
			monster.GetComponent<MonsterFollow>().battleStart = false;
			monster.GetComponent<MonsterFollow>().t = 0;
			monster.SetActive(false);
		}
	}
	
}
	