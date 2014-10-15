using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

	public float timer = 0;
	public bool started = false;
	
	public GameObject monster;
	public GameObject bridge;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(started) {
			timer += Time.deltaTime;
			if(bridge.GetComponent<Bridge>().inPlace)
			{
				Destroy(this.gameObject);
				monster.GetComponent<MonsterFollow>().stuck = false;
			}
		}
	
	}

	void OnTriggerEnter(Collider col) {
		print ("Triggered by" + col.name);
		if(col.GetComponent<MonsterFollow>()) {
			col.GetComponent<MonsterFollow>().stuck = true;
			monster = col.gameObject;
			started = true;
		}
		if(monster != null && monster.GetComponent<MonsterFollow>().stuck == true){
			if(col.GetComponent<PlayerMove>()){
				Debug.Log ("GAME OVER");
			}
		}
		
	}
}
