using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
	This Script is designed to control movement and holds values such as 
	number of lives, player number and other player related info.
	Attack scripts will be a child class of this class. See LineAttacker, AreaAttacker
*/
public class Player : NetworkBehaviour {

	protected int lives = 3;
	public Rigidbody rigid;
	NetworkTransform netTransform;

	public float speed = 5f;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody> ();

	}

	void Attack ()
	{
		//empty method to be overridden by child class
	}
	void PlayerDied()
	{
		lives -= 1;
	}
}
