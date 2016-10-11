using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
	This Script is designed to control movement and holds values such as 
	number of lives, player number and other player related info.
	Attack scripts will be a child class of this class. See LineAttacker, AreaAttacker
*/
public class Player : NetworkBehaviour {

	protected int lives;
	public Rigidbody rigid;
	NetworkTransform netTransform;

	float speed = 5f;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis ("Vertical") * Time.deltaTime * speed));

		
	
	}
}
