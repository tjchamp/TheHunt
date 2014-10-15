using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public float t = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if(t > 1f){
			Destroy(this.gameObject);
		}
	
	}
	
	
}
