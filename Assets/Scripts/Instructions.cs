using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public float 	time;
	public GUIText 	instructions;

	// Use this for initialization
	void Start () {
		instructions = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.transform.position.z < 50) {
			instructions.enabled = false;
		} else if(Camera.main.transform.position.z < 135) {
			instructions.enabled = true;
			instructions.text = "Left click to shoot, R to reload.\nF to use knife in close quarters.";
		} else if(Camera.main.transform.position.z < 180) {
			instructions.enabled = false;
		} else if(Camera.main.transform.position.z < 220) {
			instructions.enabled = true;
			instructions.text = "Use the space bar to hurdle tripping hazards.";
		} else if(Camera.main.transform.position.z < 360) {
			instructions.enabled = false;
		} else if(Camera.main.transform.position.z < 420) {
			instructions.enabled = true;
			instructions.text = "Weaken the supports with your gun,\n then rip the boards down with your knife.";
		} else if(Camera.main.transform.position.z < 500) {
			instructions.enabled = false;
		} else if(Camera.main.transform.position.z < 550) {
			instructions.enabled = true;
			instructions.text = "Cut your way through vines with your knife.";
		} else if(Camera.main.transform.position.z < 625) {
			instructions.enabled = true;
			instructions.text = "Press S to see how long\n you have before it gets you.";
		} else {
			instructions.enabled = false;
		}

	}
}
