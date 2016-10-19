using UnityEngine;
using System.Collections;

public class AreaAttacker : Player{
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


	// Use this for initialization
	void Awake () {
		anim = this.GetComponent<Animator> ();
		lvl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGen>();
		lvlAry = lvl.lvlArray;
		temp = speed;

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
			dirZ = 0;
		} else if (horz < 0) {
			//facingRight = false;
			this.GetComponent<SpriteRenderer> ().flipX = true;
			dirZ = 0;
			dirX = -1;
		} 

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
		int startZ=0;
		int startX=0;
		if (dirX == -1 || dirZ == 1) {
			startX = posX - 1;
			startZ = posZ + 1;

		} else if (dirX == 1 || dirZ == -1) {
			startX = posX + 1;
			startZ = posZ - 1;

		}
		if (dirX == -1) {
			AttackLD (startX, startZ);
		} else if (dirZ == 1) {
			AttackUR (startX, startZ);
		}
		else if (dirZ == -1) {
			AttackLD (startX, startZ);
		} else 
			AttackUR (startX, startZ);
	}
	void AttackLD (int x, int z)
	{
		for (int xx = 0; xx < 3; ++xx) {
			for (int zz = 0; zz < 3; ++zz) {
				GameObject block = lvlAry [x - xx, z - zz];
				block.GetComponent<Renderer> ().material.color = Color.red;
				block.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
			}
		}
	}
	void AttackUR (int x, int z)
	{
		for (int xx = 0; xx < 3; ++xx) {
			for (int zz = 0; zz < 3; ++zz) {
				GameObject block = lvlAry [x + xx, z + zz];
				block.GetComponent<Renderer> ().material.color = Color.red;
				block.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
			}
		}
	}
}
