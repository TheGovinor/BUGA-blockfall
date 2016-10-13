using UnityEngine;
using System.Collections;

public class FallCollider : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{	
		if (col.tag == "Level") {
			//reset color from attack color
			col.GetComponent<Renderer> ().material.color = Color.white;
			//freeze all constraints
			col.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			//reset position
			col.transform.position = new Vector3 ((int)col.transform.position.x, 0, (int)col.transform.position.z);
		}
		if (col.tag == "Player") {
			col.SendMessage ("PlayerDied");
		}
	}
}
