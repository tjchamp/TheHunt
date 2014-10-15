using UnityEngine;
using System.Collections;

public class display : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string hiscore = "HiScore: " + PlayerPrefs.GetFloat ("Hi_Score");
		string score = "Score: " + PlayerPrefs.GetFloat ("Player_Score");
		guiText.text = hiscore + "\n" + score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
