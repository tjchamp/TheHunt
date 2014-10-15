using UnityEngine;
using System.Collections;

public class EnemyJump : MonoBehaviour {

	public float 	jumpDistance = 10f;
	public float	latchDistance = 2.5f;
	public bool		jumping = false;
	public float	easing = 0.05f;
	public bool		latched = false;
	public float pullSpeed = 1f;
	public GameObject bridge;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(transform.position.z - Camera.main.transform.position.z) < jumpDistance && !jumping && !latched)
		{
			GetComponent<EnemyMove>().speed = 0;
			jumping = true;
		} 
		else if(Mathf.Abs(transform.position.z - Camera.main.transform.position.z) < latchDistance && jumping)
		{
			jumping = false;
			latched = true;
		}
		if(jumping)
		{
			this.GetComponent<Animator>().SetInteger ("EnemyState", 2);
			Vector3 destination = Camera.main.transform.position;
			destination = Vector3.Lerp (transform.position, destination, easing);
			//destination = (destination - transform.position);
			//destination.x *= 2 * easing; destination.y *= 2*easing; destination.z *= easing;
			//destination = transform.position + destination;
			transform.position = destination;
		}
		if(latched)
		{
			Vector3 destination = Camera.main.transform.position;
			destination.z += transform.position.z > Camera.main.transform.position.z ? latchDistance: -latchDistance;
			transform.position = destination;
			if(GameObject.Find("Player").GetComponent<PlayerMove>().canPull == true){
				destination = Camera.main.transform.parent.position;
				destination.z -= pullSpeed * Time.deltaTime;
				Camera.main.transform.parent.position = destination;
				destination.z -= latchDistance;
				transform.position = destination;
			}
		}
	}
}
