using UnityEngine;
using System.Collections;

public class get_score : MonoBehaviour {
	public bool score_taken = false;
	public GameObject gui_score;

	void OnTriggerEnter (Collider other) {
		if (other.name == "Player" && !score_taken) {
			score_taken = true;
			float t = other.gameObject.GetComponent<PlayerMove> ().game_start_time;
			t = Time.time - t;
			PlayerPrefs.SetFloat ("Player_Score", t);
			if (PlayerPrefs.GetFloat ("Hi_Score") > t || PlayerPrefs.GetFloat ("Hi_Score") == 0) {
				PlayerPrefs.SetFloat ("Hi_Score", t);
			}
			Instantiate (gui_score);
		}
	}
}
