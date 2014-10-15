using UnityEngine;
using System.Collections;
//add to the spawnpoint refab.

public class hoard_spawn : MonoBehaviour {
	
	public GameObject enemy_prefab;
	public float enemies_before_cooldown = 6;
	public float cooldown_duration = 4;
	public float spawn_delay = .25f;
	public float room_min_x, room_max_x;
	float counter = 0;
	float cooldown_start_t = 0;
	float last_spawn_t = 0;
	Vector3 newPosition;
	public bool spawning = false;

	void start () {
	}

	// Update is called once per frame
	void Update () {
		if(spawning) {
			if (counter >= enemies_before_cooldown) {
				if (Time.time - cooldown_start_t >= cooldown_duration) {
					counter = 0;
				}
			} 
			else if (Time.time - last_spawn_t >= spawn_delay) {
				GameObject enemy = (GameObject)Instantiate (enemy_prefab, transform.position,
				                                            enemy_prefab.gameObject.transform.rotation);
				newPosition.x = Random.Range (room_min_x, room_max_x);
				enemy.transform.Translate (newPosition);
				enemy.transform.Rotate(Vector3.right, 180);
				enemy.GetComponent<EnemyMove>().animationState = 1;
				++counter;
				last_spawn_t = Time.time;

				if (counter >= enemies_before_cooldown) {
					cooldown_start_t = Time.time;
				}
			}
		}
	}
}
