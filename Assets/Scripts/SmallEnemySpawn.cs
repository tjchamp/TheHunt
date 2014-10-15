using UnityEngine;
using System.Collections;

enum Edge {
	top,
	right,
	bottom,
	left
}

public class SmallEnemySpawn : MonoBehaviour {

	public GameObject prefabSmallEnemy;

	public float timePassed = 0;
	public float MaxTimeBetweenEnemies = 60;
	public float MinTimeBetweenEnemies = 5;
	public float timeUntilNextSpawn = 60;
	
	float cameraSize = 2.75f;
	float cameraAspect = 1;
	//Sprite[] jellyfish;
	//Sprite[] slime;

	// Use this for initialization
	void Start () {
		//jellyfish = Resources.LoadAll<Sprite>("Jellyfish");
		//slime = Resouces.LoadAll<Sprite>("Slime");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time < 7.5) return;

		timePassed += Time.deltaTime;

		MaxTimeBetweenEnemies = Mathf.Max(MaxTimeBetweenEnemies - Time.deltaTime * 0.01f, 1.5f);
		MinTimeBetweenEnemies = Mathf.Max(MinTimeBetweenEnemies - Time.deltaTime * 0.01f, 0.5f);

		if(timePassed > timeUntilNextSpawn) {

			GameObject enemy = Instantiate(prefabSmallEnemy) as GameObject;
			Vector3 startPos = Vector3.zero;
			
			
			int rand = Random.Range(0, (int)Edge.left + 1);
			Edge startEdge = (Edge)rand;

			Vector2 center = Camera.main.transform.position;
			center.y += 2.5f;
			
			if(startEdge == Edge.top || startEdge == Edge.bottom)
			{
				enemy.GetComponent<EnemyMove>().animationState = 3;	
				startPos.y = center.y + ((startEdge == Edge.top) ? cameraSize : -cameraSize);
				if(startEdge == Edge.top)enemy.transform.Rotate(Vector3.left, 180);	
				if(startEdge == Edge.top)enemy.transform.Rotate(Vector3.down, 180);	
						
				startPos.x = Random.Range(center.x - cameraSize * cameraAspect, center.x + cameraSize * cameraAspect);
			} else{
				enemy.GetComponent<EnemyMove>().animationState = 1;
				startPos.x = center.x + (startEdge == Edge.right ? cameraSize : -cameraSize) * cameraAspect;
				startPos.y = Random.Range(center.y - cameraSize, center.y + cameraSize);
			}
			startPos.z = Camera.main.transform.position.z + 220;
			enemy.transform.position = startPos;
			enemy.GetComponent<EnemyMove>().speed += Time.time * 0.05f;

			timePassed = 0;
			timeUntilNextSpawn = Random.Range(MinTimeBetweenEnemies, MaxTimeBetweenEnemies);
		}
	}
}
