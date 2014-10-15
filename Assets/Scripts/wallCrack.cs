using UnityEngine;
using System.Collections;

public class wallCrack : MonoBehaviour {

	public int durability = 3;
	public GameObject debris;
	GameObject block;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(durability <= 0 && Camera.main.transform.position.z > this.transform.position.z && block == null){
			block = Instantiate (debris) as GameObject;
			Vector3 temp = this.transform.position;
			temp.y -= 2.5f;
			temp.x -= 2f;
			block.transform.position = temp;
			
				
			
		}
		if(block != null){
			block.transform.rotation = Quaternion.Lerp (block.transform.rotation, Quaternion.Euler(0, 0, 45), 4*Time.deltaTime);
		}
	
	}
}
