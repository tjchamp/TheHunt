using UnityEngine;
using System.Collections;

public class attach : MonoBehaviour {
	public float hp = 5f;

	void Awake(){

		}
	void OnTriggerEnter (Collider other) {
		//Debug.Log ("attached");
		//Req rigidbody and isTrigger
		if (other.gameObject.GetComponent<PlayerMove> ()) {
			transform.parent = other.gameObject.transform;

			other.gameObject.GetComponent<Knife_Swing> ().num_attached_enemies++;
		}
	}


}