using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed = 5;
	public int animationState = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<Animator>().SetInteger ("EnemyState", animationState);
		float curSpeed = transform.position.z < Camera.main.transform.position.z ? -speed : speed;
		Vector3 pos = transform.position;
		pos.z -= curSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
