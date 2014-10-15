using UnityEngine;
using System.Collections;

public class MonsterFollow : MonoBehaviour {

	public float speed = 6f;
	public bool stuck = false;
	public bool battleStart = false;
	public bool respawn = false;
	public float t = 0;
	public GameObject EyeHit;
	public GameObject EyeHit2;
	public GameObject MouthHit;
	public GameObject MonsterLeftHand;
	public GameObject Monster;
	public int hitsBeforeStun = 5;
	bool hitStun = false;
	public bool lastRoom = false;
	public bool gameOver = false;
	public AudioClip roar;
	
	public GameObject minionSpawner;
	public GameObject ObstacleSpawner;
	public GameObject tripSpawner;
	public GameObject vineSpawner;
	public GameObject [] minions;
	

	// Use this for initialization
	void Start () {
		audio.Play();
		EyeHit.SetActive(false);
		EyeHit2.SetActive (false);
		MouthHit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOver){
		if(!stuck && !battleStart && !lastRoom) {
			if(this.transform.position.z > Camera.main.transform.position.z - 45){
				speed = 6f;
				Vector3 pos = this.transform.position;
				pos.z += speed*Time.deltaTime;
				this.transform.position = pos;
				if(this.transform.position.z > Camera.main.transform.position.z - 25){

					
				}
				else if(this.transform.position.z > Camera.main.transform.position.z - 10){

					//audio.PlayOneShot (fastRun);
				}
				
			}
			else if(!battleStart && !lastRoom){

				//audio.PlayOneShot (slowRun);
				speed = 10f;
				Vector3 pos = this.transform.position;
				pos.z += speed*Time.deltaTime;
				this.transform.position = pos;
			}
		}
		
		if(battleStart){
			//Monster.audio.Stop ();
			//MonsterLeftHand.audio.Play ();
			//audio.Play ();
			t += Time.deltaTime;
			this.GetComponentInChildren<Animator>().SetInteger ("MonsterState", 2);
			EyeHit.SetActive(true);
			EyeHit2.SetActive (true);
			MouthHit.SetActive(true);
			if(!hitStun)
				speed = 15f;
			else{
			Debug.Log ("STUNNED");
				this.GetComponentInChildren<Animator>().SetInteger ("MonsterState", 1);
				//MonsterLeftHand.audio.Play ();
				speed = -8f;
				if(t > 3f)
					hitStun = false;
			}
			Vector3 pos = this.transform.position;
			pos.z += speed*Time.deltaTime;
			this.transform.position = pos;
			
			if(hitsBeforeStun <= 0){
				hitStun = true;
				hitsBeforeStun = 5;
				t = 0;
			}
			
		}
		
		if(lastRoom){
			Vector3 position = Camera.main.transform.position;
			position.y += .05f * Mathf.Sin(Time.time * 3f * Mathf.PI);
			Camera.main.transform.position = position;
			Vector3 tempPos = Camera.main.transform.position;
			audio.Pause ();
			speed = 0;
			t += Time.deltaTime;
			//if(t > 2f){
			if(t > 2f && t < 3f){
				tempPos = GameObject.Find ("LeftWallSound").transform.position;
				tempPos.x += 12;
				this.transform.position = tempPos;
				this.transform.LookAt (Camera.main.transform.position);
				//if(GameObject.Find ("LeftWallSound").audio.isPlaying)Debug.Log ("HOORAy");
				if(!GameObject.Find ("LeftWallSound").audio.isPlaying)
					GameObject.Find("LeftWallSound").audio.Play (); 
					//GameObject.Find ("LeftWallSound").audio.Stop ();
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.left), 10*Time.deltaTime);
			
			}
			if(t > 5f && t < 7f){
				tempPos.y += 40;
				this.transform.position = tempPos;
			}
			if(t > 9f && t < 10f){
				tempPos = GameObject.Find ("RightWallSound").transform.position;
				tempPos.x -= 18f;
				tempPos.z -= 3f;
				tempPos.y -= 2f;
				this.transform.position = tempPos;
				this.transform.LookAt (Camera.main.transform.position);
				if(!GameObject.Find ("RightWallSound").audio.isPlaying)
					GameObject.Find("RightWallSound").audio.Play (); 
					//GameObject.Find ("RightWallSound").audio.Stop ();
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.right), 10*Time.deltaTime);
			}
			if(t > 11f && t < 13f){
				tempPos.y += 40;
				this.transform.position = tempPos;
			}
			if(t > 13f && t < 14f){
				audio.Play ();
				
			}
			if(t > 14f){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.back), 3*Time.deltaTime);
			}
			if(t > 15f && t < 19f){
				GameObject.Find ("WallSound").audio.Stop ();
				tempPos = Vector3.zero;
				this.transform.LookAt (Vector3.forward);
				tempPos.z = 1800;
				this.audio.Play ();
				this.transform.position = tempPos;
				
			}
			if(t > 19f){
				speed = 30f;
				tempPos = this.transform.position;
				tempPos.z += speed*Time.deltaTime;
				this.transform.position = tempPos;
				this.audio.PlayOneShot (roar);
				//if(!GameObject.Find ("MonsterLeftHand").audio.isPlaying)
					//GameObject.Find("MonsterLeftHand").audio.Play (); 
			}
			//}
		}
		}
		// Game Over
		if(transform.position.z > Camera.main.transform.position.z + 2 && !gameOver) {
			gameOver = true;
			speed = -1;
			//GameObject hand = Instantiate(prefabHand) as GameObject;
			//hand.transform.parent = this.transform;
			
			
			minions = GameObject.FindGameObjectsWithTag("Minion");
			foreach(GameObject minion in minions) Destroy(minion.gameObject);
			
			
			minionSpawner.GetComponent<SmallEnemySpawn>().enabled = false;
			ObstacleSpawner.GetComponent<PlankObstacleSpawn>().enabled = false;
			tripSpawner.GetComponent<TripHazardSpawn>().enabled = false;
			vineSpawner.GetComponent<VineSpawn>().enabled = false;
			
			GameObject player = GameObject.Find("Player");
			player.GetComponent<PlayerMove>().dead = true;
			player.GetComponent<Knife_Swing>().num_attached_enemies = 0;
			player.GetComponent<PlayerMove>().deathCameraPos = Camera.main.transform.position;
			player.GetComponent<PlayerMove>().deathCameraPos.y -= 1;
			player.transform.parent = this.transform;
			player.renderer.enabled = false;
			
		}
		if(gameOver) {
			Vector3 pos = this.transform.position;
			pos.z += speed*Time.deltaTime;
			this.transform.position = pos;
		}
		
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.GetComponent<PlayerMove>()){
			Debug.Log ("GAME OVER");
		}
	}
}
