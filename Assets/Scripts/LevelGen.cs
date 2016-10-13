using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelGen : MonoBehaviour {
	//this script generates a level for the game, dimensions are public and can be set outside the class
	//level is created into squares and each is added to a 2d array
	public GameObject[,] lvlArray;
	GameObject [] spawnpoints = new GameObject[20];
	public int dimensionX = 50;
	public int dimensionY = 50;

	Transform levelParent;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < spawnpoints.Length; i++) {
			spawnpoints[i] = new GameObject("pos " + i);
			spawnpoints [i].AddComponent<NetworkStartPosition> ();
			spawnpoints [i].transform.position = new Vector3 (Random.Range (0, dimensionX), 2, Random.Range(0, dimensionY));
		}

		lvlArray = new GameObject[dimensionX, dimensionY];
		levelParent = GameObject.Find ("Level").GetComponent<Transform> ().transform;


		//create Level based on 2D array, instantiate cubes at each value
		for (int x = 0; x < dimensionX; x++) {
			for (int y = 0; y < dimensionY; y++) {
				lvlArray[x,y] = Instantiate (Resources.Load("Prefabs/Cube"), new Vector3 (x, 0, y), Quaternion.identity, levelParent) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		


	
	}
}
