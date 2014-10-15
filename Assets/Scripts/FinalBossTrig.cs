using UnityEngine;
using System.Collections;

public class FinalBossTrig : MonoBehaviour {
	public GameObject monster;
	public GameObject spawner;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.GetComponent<PlayerMove>()){
			monster.GetComponent<MonsterFollow>().battleStart = true;
			audio.Play ();
		}
	}
}
