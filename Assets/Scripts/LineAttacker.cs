using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LineAttacker : Player {
	public int posX;
	public int posZ;
	public GameObject[,] lvlAry;
	float horz;
	float vert;
	float temp;

	public int dirX = 0;
	public int dirZ = 0;
	LevelGen lvl;
	Animator anim;
	//bool facingRight;

	// Use this for initialization
	void Awake () {
		anim = this.GetComponent<Animator> ();
		lvl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGen>();
		lvlAry = lvl.lvlArray;
		temp = speed;

		//facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		if (lives == 0) {
			//if player has died, set them to inactive
			this.gameObject.SetActive (false);
		}
		//check player's axis input and assign
		horz = Input.GetAxisRaw ("Horizontal");
		vert = Input.GetAxisRaw ("Vertical");

		//control player movement
		this.transform.Translate (new Vector3 (horz * speed * Time.deltaTime, 0, vert * Time.deltaTime * speed));

		//freeze player when attack animatino is playing
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {
			speed = 0;
		} else
			speed = temp;

		//check player facing left or right
		if (horz > 0) {
			//facingRight = true;
			this.GetComponent<SpriteRenderer> ().flipX = false;
			dirX = 1;
		} else if (horz < 0) {
			//facingRight = false;
			this.GetComponent<SpriteRenderer> ().flipX = true;
			
			dirX = -1;
		} 

		/*
		use this if above does not work for flipping sprite
		if (facingRight == true) {

		} else
		*/	

		if (vert > 0) {
			//facingRight = true;
			anim.SetInteger ("Vertical", 1);
			dirX = 0;
			dirZ = 1;
		} else if (vert < 0) {
			//facingRight = false;
			anim.SetInteger ("Vertical", -1);
			dirX = 0;
			dirZ = -1;
		} 

		//control player attack
		if (Input.GetButtonDown("Fire1"))
		{
			Attack ();
		}

		posX = (Mathf.RoundToInt (this.transform.position.x)) + dirX;
		posZ = (Mathf.RoundToInt (this.transform.position.z)) + dirZ;
	
	}
	void Attack ()
	{
		anim.SetTrigger ("Attack");
		int z=0;
		int x=0;

		for (int i = 0; i < 9; i++) {
			GameObject block = lvlAry [posX + x, posZ + z];
			block.GetComponent<Renderer> ().material.color = Color.red;
			block.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
			if (dirX != 0) {
				x += dirX;
			} else if (dirZ != 0) {
				z += dirZ;
			} 
		}

	}
}
