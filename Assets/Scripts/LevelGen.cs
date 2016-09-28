using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {
	public int dimensionX = 5;
	public int dimensionY = 5;
	Transform levelParent;

	// Use this for initialization
	void Start () {
		GameObject[,] levelAry = new GameObject[dimensionX, dimensionY];
		//square = GameObject.CreatePrimitive (PrimitiveType.Cube);
		levelParent = GameObject.Find ("Level").GetComponent<Transform> ().transform;
		//square.transform.SetParent (levelParent);


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
