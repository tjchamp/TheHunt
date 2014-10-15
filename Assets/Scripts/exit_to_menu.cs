using UnityEngine;
using System.Collections;

public class exit_to_menu : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("menu");
		}
	}
}
