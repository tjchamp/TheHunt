using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {
	public GameObject player;


	void Awake(){
		}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.name != "Player" && other.gameObject.GetComponent<attach> ()) {
			player = GameObject.Find ("Player");
			float hp, num_enemies, dmg;
			dmg = player.GetComponent<Knife_Swing>().dmg;
			num_enemies = player.GetComponent<Knife_Swing>().num_attached_enemies;

			other.gameObject.GetComponent<attach>().hp -= (dmg/num_enemies);
			hp = other.gameObject.GetComponent<attach> ().hp;
			if (hp <= 0) {
				Destroy (other.gameObject);
				player.GetComponent<Knife_Swing>().num_attached_enemies--;
			}
		}
		Destroy (this);
	}
}
