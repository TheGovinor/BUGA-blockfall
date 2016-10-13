using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LineAttacker : Player {
	public int posX;
	public int posZ;
	int dirX = -1;
	int dirZ = 0;
	LevelGen lvl;
	public GameObject[,] lvlAry;
	Animator anim;

	// Use this for initialization
	void Awake () {
		anim = this.GetComponent<Animator> ();
		lvl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGen>();
		lvlAry = lvl.lvlArray;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		if (lives == 0) {
			//if player has died, set them to inactive
			this.gameObject.SetActive (false);
		}
		//control player movement
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis ("Vertical") * Time.deltaTime * speed));
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
		int z=0;
		int x=0;

		for (int i = 0; i < 9; i++) {
			//float timer = 2f;
			//implement timer before block falls
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
