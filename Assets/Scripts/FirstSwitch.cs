using UnityEngine;
using System.Collections;

public class FirstSwitch : MonoBehaviour {

	public GameObject bridge;
	public GameObject player;
	public GameObject hoard_spawn;
	public bool switched = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(switched && !Input.GetKey(KeyCode.S) && bridge.GetComponent<Bridge>().inPlace == false)
		{
			Vector3 angle = transform.eulerAngles;
			angle = transform.eulerAngles + 180f * Vector3.up;
			Camera.main.transform.eulerAngles = Vector3.Lerp (Camera.main.transform.eulerAngles, angle, 15*Time.deltaTime);
		} else if(switched && bridge.GetComponent<Bridge>().inPlace == false)
		{
			PlayerMove.speed = 0;
			Vector3 angle = transform.eulerAngles;
			angle = transform.eulerAngles + Vector3.up;
			Camera.main.transform.eulerAngles = Vector3.Lerp (Camera.main.transform.eulerAngles, angle, 15*Time.deltaTime);
			
		} 
		if(switched && Camera.main.transform.position.z < transform.position.z - 10){
			PlayerMove.speed = 10f;
		}
		else if(switched){
			PlayerMove.speed = 0;
				}
		if(bridge.GetComponent<Bridge>().inPlace == true){
			PlayerMove.speed = 10f;
		}
	}

	void OnMouseDown() {
		if(Camera.main.transform.position.z > transform.position.z - 10) {
			bridge.GetComponent<Bridge>().activated = true;
			hoard_spawn.GetComponent<hoard_spawn>().spawning = true;
			switched = true;
		}
	}
}
