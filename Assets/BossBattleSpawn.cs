using UnityEngine;
using System.Collections;

public class BossBattleSpawn : MonoBehaviour {

	public GameObject 	bossRoomPrefab;
	Vector3 	battlePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.GetComponent<PlayerMove>()) {
			GameObject BossRoom = Instantiate(bossRoomPrefab) as GameObject;
			battlePosition = BossRoom.transform.position;
			battlePosition.z = Camera.main.transform.position.z + 300;
			BossRoom.transform.position = battlePosition;
			Destroy(gameObject);
		}
	}
}
