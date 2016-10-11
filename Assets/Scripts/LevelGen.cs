using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {
	//this script generates a level for the game, dimensions are public and can be set outside the class
	//level is created into squares and each is added to a 2d array


	public int dimensionX = 20;
	public int dimensionY = 20;
	Transform levelParent;

	// Use this for initialization
	void Start () {
		GameObject[,] levelAry = new GameObject[dimensionX, dimensionY];
		levelParent = GameObject.Find ("Level").GetComponent<Transform> ().transform;


		//create Level based on 2D array, instantiate cubes at each value
		for (int x = 0; x < dimensionX; x++) {
			for (int y = 0; y < dimensionY; y++) {
				GameObject temp = Instantiate (Resources.Load("Prefabs/Cube"), new Vector3 (x, 0, y), Quaternion.identity, levelParent) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		


	
	}
}
