using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	// Use this for initialization
	public string option1, option2, option3;
	public float min = -90;
	public float max = -50;
	string option;
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("1")){
			Application.LoadLevel("_Scene_0");
		}
		else if(Input.GetKeyDown("2")){
			Application.LoadLevel("instructions");
		}
		else if(Input.GetKeyDown ("3")){
			Application.LoadLevel("credits");
		}
		GameObject pointer = GameObject.Find ("pointer");
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (pointer.transform.position.y - 20 > (min - 10)) {
				pointer.transform.position = new Vector3 (pointer.transform.position.x,
					                                      pointer.transform.position.y - 20,
			         	                                  pointer.transform.position.z);
			}
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (pointer.transform.position.y + 20 < max) {
				pointer.transform.position = new Vector3 (pointer.transform.position.x,
			    	                                      pointer.transform.position.y + 20,
			        	                                  pointer.transform.position.z);
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (pointer.transform.position.y < (min)) {
				option = option3;
			}
			else if (pointer.transform.position.y < (min + 20)) {
				option = option2;
			}
			else if (pointer.transform.position.y < (min + 40)) {
				option = option1;
			}
			Application.LoadLevel (option);
		}
		/*else if (Input.anyKeyDown) {

			Application.LoadLevel ("benny_knife");
		}*/
	}
}
