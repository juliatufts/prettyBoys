using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject sprite;
	private bool firing;
	public Sprite normal;
	public Sprite shooting;

	float direction = 0;

	Animator animator;
	ParticleSystem particles;

	// Use this for initialization
	void Start () {
		firing = false;
		animator = sprite.GetComponent<Animator>();
		particles = GetComponentInChildren<ParticleSystem>();
		particles.Stop();
		// -.5 and .5 disable/enable on trigger/animation stuff
	}

	void HitBoy(){
		RaycastHit hit;
		var pos = transform.position;
		var posB = pos;
		posB.x += .5f;
		pos.x -=.5f;

		Debug.DrawRay(posB, -Vector3.right, Color.blue, 10);

		if (Physics.Raycast(pos, Vector3.right, out hit)){
			if (hit.transform.name.Equals("Boy") && hit.distance < .9f){
				hit.transform.GetComponent<Boy>().Leggings();
			}
		}

		if (Physics.Raycast(posB, -Vector3.right, out hit)){
			if (hit.transform.name.Equals("Boy") && hit.distance < .9f){
				hit.transform.GetComponent<Boy>().Leggings();
			}
		}
	}

	void Leggings(){

	}
	
	void FixedUpdate(){
		//player movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		bool moving = false;

		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && Mathf.Abs(Input.GetAxis("Vertical")) > 0){
			transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed/2 * Time.deltaTime, 0, 0)); 
			transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * speed/2 * Time.deltaTime, 0)); 
			moving = true;
		} else if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0){
			transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0)); 
			moving = true;
		} else if(Mathf.Abs(Input.GetAxis("Vertical")) > 0){
			transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * speed/2 * Time.deltaTime, 0)); 
			moving = true;
		}

		animator.SetBool("moving", moving);

		if(moveHorizontal < 0){
			direction = 180;
		} else if (moveHorizontal > 0) {
			direction = 0;
		}

		sprite.transform.rotation = Quaternion.Euler(new Vector3 (0, direction, 0));

		//Space fires
		if(Input.GetKeyDown(KeyCode.Space) && !firing){
			animator.SetBool("wand", true);
			HitBoy ();
			firing = true;

		}

		if (direction == 180){
			particles.transform.localPosition = new Vector3(-.6f, 0, 0);
		}
		else{
			particles.transform.localPosition = new Vector3(.6f, 0, 0);
		}

		if (firing){
			if (!animator.GetCurrentAnimationClipState(0)[0].clip.name.Equals("wand")){
				firing = false;
			}
			particles.Emit(50);
		}
	}
}
