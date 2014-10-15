using UnityEngine;
using System.Collections;

public class quicksand : MonoBehaviour {

	public float sink_factor = .5f;
	public float player_height = -10;
	public float drown_line = -100;
	public float freed_line = 0;
	public float sink_delay = .5f;
	float last_delayed_time = 0;

	void Start () {
		update_height (player_height);
	}
	void Update () {
		GameObject player = GameObject.Find ("player");

		if ((Time.time - last_delayed_time) >= sink_delay) {
			player_height -= sink_factor;
			update_height ((-1 * sink_factor));
			last_delayed_time = Time.time;	
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			++player_height;
			update_height (1);
		}
		if (in_over_his_head () == "true") {

			Destroy (player);
		}
		if (player_height >= freed_line) {

			//float base_speed;
			//base_speed = player.GetComponent<PlayerMove> ().base_speed;
			//player.GetComponent<PlayerMove> ().speed = base_speed;
			//Destroy (this);
		}
	}
	string in_over_his_head () {
		if (player_height <= drown_line) {
			return "true";
		}
		return "false";
	}

	void update_height(float height_inc) {
		//player.transform.position.y -= (sink_val / 100);
		GameObject player = GameObject.Find ("Player");
		player.transform.position = new Vector3 (player.transform.position.x,
		                                         player.transform.position.y + (height_inc/50),
		                                         player.transform.position.z);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<PlayerMove> ()) {
			PlayerMove.speed = 0;
			Debug.Log ("Stuck!");
		}
	}
	void OnTriggerExit (Collider other) {
		if (other.gameObject.GetComponent<PlayerMove> ()) {
			float base_speed;
			base_speed = other.gameObject.GetComponent<PlayerMove> ().base_speed;
			PlayerMove.speed = base_speed;
		}
		Destroy (this);


	}
}
