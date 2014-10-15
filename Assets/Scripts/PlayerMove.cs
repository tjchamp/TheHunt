using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public static float speed = 10f;
	public float base_speed = 10f;//benny
	public GameObject bulletDebris;
	public int bulletCount = 6;
	public int turnAround = 0; // 1 = left, 2 = right, 3 = behind
	public AudioClip shotSound;
	public AudioClip shotFail;
	public AudioClip reload;
	public AudioClip knifeSwipe;
	public float t = 0;
	public bool canPull = false;
	bool reloadStart = false;
	public bool boss = false;
	public bool lastRoom = false;
	
	public GameObject knife;
	public bool stabbing = false;
	
	public bool jumping = false;
	public Vector3 jumpVel = new Vector3(0, 10f, 0);
	public Vector3 vel;
	
	public bool dead = false;
	public float timeSinceDeath = 0;
	public Vector3 deathCameraPos;
	public float game_start_time;
	
	
	// Use this for initialization
	void Start () {
		knife.renderer.enabled = false;
		game_start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(lastRoom){
			if(Camera.main.GetComponentInChildren<orient_bullets>() != null)
				Destroy(Camera.main.GetComponentInChildren<orient_bullets>().gameObject);
			bulletCount = 0;	
		}
		
		//Debug.Log (speed);
		if(Time.timeSinceLevelLoad < 11f) {
			if(Time.timeSinceLevelLoad < 2.5f) {
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(new Vector3(1, 0, -0.2f)), 2*Time.deltaTime);
			} else if(Time.timeSinceLevelLoad < 5f) {
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(new Vector3(-1, 0, 0.2f)), 2*Time.deltaTime);
			} else if(Time.timeSinceLevelLoad < 7.5){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.up), 2 * Time.deltaTime);
			} else {
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.back), 2 * Time.deltaTime);
			}
			return;
		}else if(dead) {
			timeSinceDeath += Time.deltaTime;
			if(timeSinceDeath < 1f) {
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.back), 4 * Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, deathCameraPos, 8 * Time.deltaTime);
			} 
			if(timeSinceDeath > 2)
				ScreenFadeOut.endOfGame = true;
			if(timeSinceDeath > 3)
				Application.LoadLevel ("menu");
			return;
		}
		
		if(reloadStart){
			
			t += Time.deltaTime;
			if(t > .25f){
				inc_bullets ();
				t = 0;
				audio.PlayOneShot (reload);
			}
			if(bulletCount == 6)
				reloadStart = false;
		}
		if(this.GetComponent<Knife_Swing>().num_attached_enemies == 0) {
			Vector3 currPos = transform.position;
			currPos.z += speed * Time.deltaTime;
			transform.position = currPos;
			//Camera.main.transform.position = transform.position;
			
		}
		if(!lastRoom){
			if(turnAround == 1 && !boss){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.left), 10*Time.deltaTime);
			}
			else if(turnAround == 2 && !boss){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.right), 10*Time.deltaTime);
			}
			else if(turnAround == 3 && !boss){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.back), 10*Time.deltaTime);
			}
			else if(turnAround == 0 && !boss){
				Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, Quaternion.LookRotation(Vector3.forward), 10*Time.deltaTime);
			}
		}
		if(Input.GetButtonDown ("Fire1") && bulletCount > 0 && this.GetComponent<Knife_Swing>().num_attached_enemies == 0 && !lastRoom){

			//Debug.Log ("Shot Fired");
			reloadStart = false;
			dec_bullets ();
			Ray rayHit = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			audio.PlayOneShot (shotSound);
			if(Physics.Raycast (rayHit, out hitInfo)){
				Debug.Log (hitInfo.collider.gameObject.name);
				Debug.Log (hitInfo.collider.transform.root.gameObject.name);
				Vector3 hitPoint = hitInfo.point;
				
				if(hitInfo.collider.GetComponent<PlankFlaw>())
					hitInfo.collider.GetComponent<PlankFlaw>().ShootFlaw();
				else if(hitInfo.collider.GetComponent<EnemyMove>()){
					Destroy(hitInfo.collider.gameObject);				
					
				}
				else if(hitInfo.collider.transform.root.gameObject.GetComponent<MonsterFollow>()){
					Debug.Log ("ALLALAALALALALALAL");
					if(hitInfo.collider.gameObject.transform.root.gameObject.GetComponent<MonsterFollow>().battleStart == true){
						if(hitInfo.collider.gameObject.name == "MouthHitbox") hitInfo.collider.gameObject.transform.root.GetComponent<MonsterFollow>().hitsBeforeStun --;
						else if(hitInfo.collider.gameObject.name == "EyeHitbox" || hitInfo.collider.gameObject.name == "EyeHitbox2") 
							hitInfo.collider.gameObject.transform.root.GetComponent<MonsterFollow>().hitsBeforeStun -= 5;
					}
					
				}
				else if(hitInfo.collider.GetComponent<wallCrack>()){
					hitInfo.collider.GetComponent<wallCrack>().durability--;
				}
				else{
					GameObject debris = Instantiate (bulletDebris) as GameObject;
					debris.transform.position = hitPoint;
				}
				
			}
		}
		else if(Input.GetButtonDown ("Fire1") && bulletCount == 0)
			audio.PlayOneShot (shotFail);
		if(Input.GetButtonDown ("Reload")){
			reloadStart = true;
		}
		if(Input.GetKey (KeyCode.A)){
			turnAround = 1;
		}
		else if(Input.GetKey(KeyCode.D)){
			turnAround = 2;
		}
		else if(Input.GetKey(KeyCode.S)){
			turnAround = 3;			
		}
		else{
			turnAround = 0;
		}
		if(Input.GetKeyDown(KeyCode.F)) {
			knife.renderer.enabled = true;
			audio.PlayOneShot (knifeSwipe, 3);
			stabbing = true;
		} if(stabbing)
		{
			knife.transform.RotateAround(transform.position, Vector3.down, 720 * Time.deltaTime);
			if(knife.transform.rotation.eulerAngles.y < 50) {
				knife.renderer.enabled = false;
				knife.transform.rotation = Quaternion.Euler(new Vector3(0, 150, 86));
				knife.transform.localPosition = new Vector3(0.0f, -0.1f, 0.35f);
				stabbing = false;
			}
		}
		
		if(Input.GetButtonDown("Jump") && !jumping && GetComponent<Knife_Swing>().num_attached_enemies == 0) {
			jumping = true;
			vel = jumpVel;
		}
		if(jumping) {
			Vector3 pos = transform.position;
			if(transform.position.y < -2.5f)
			{
				jumping = false;
				pos.y = -2.5f;
			} else {
				vel += new Vector3(0, -25f, 0) * Time.deltaTime;
				pos += vel * Time.deltaTime;
			}
			transform.position = pos;
		}
	}
	
	void updateSpeed () {
		GameObject player = this.gameObject;
		//GameObject player = GameObject.Find ("Player");
		float speed_offset, num_attached_enemies, slowdown_factor;//, base_speed;
		num_attached_enemies = player.GetComponent<Knife_Swing> ().num_attached_enemies;
		slowdown_factor = player.GetComponent<Knife_Swing> ().slowdown_factor;
		//base_speed = player.GetComponent<PlayerMove> ().base_speed;
		
		if (num_attached_enemies <= 0) {
			speed_offset = base_speed;
		} 
		else {
			speed_offset = (num_attached_enemies * slowdown_factor);
			//player.GetComponent<PlayerMove> ().
			speed = base_speed * speed_offset;
		}
	}//benny

	void dec_bullets () {
		
		if (bulletCount != 0) {
			GameObject bullet = GameObject.Find (("b_" + bulletCount));
			bullet.gameObject.renderer.enabled = false;
		}
		--bulletCount;
	}
	
	void reset_bullets () {
		string bullet_name;
		for (int i = 1; i <= 6; ++i) {
			bullet_name = "b_" + i;
			GameObject bullet = GameObject.Find (bullet_name);
			bullet.renderer.enabled = true;
		}
		bulletCount = 6;
	}
	
	void inc_bullets () {
		++bulletCount;
		GameObject bullet = GameObject.Find (("b_" + bulletCount));
		bullet.gameObject.renderer.enabled = true;
	}
}

