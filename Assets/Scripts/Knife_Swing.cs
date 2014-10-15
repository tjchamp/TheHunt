using UnityEngine;
using System.Collections;

public class Knife_Swing : MonoBehaviour {
	
	public GameObject arms_reach;
	public float dmg = 5f;
	public float num_attached_enemies = 0f;
	public float slowdown_factor = 0.6f;
	public float speed_offset;

	void Awake(){
		}

	void Update () {


		if (Input.GetKeyDown (KeyCode.F)) {
			//Object i;
			var i = Instantiate (arms_reach, transform.position, arms_reach.transform.rotation);
			Destroy (i, 1);
		}
	}


}
