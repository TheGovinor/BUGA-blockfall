using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {
	GameObject square;
	public int dimensionX;
	public int dimensionY;
	public GameObject[][] levelAry;

	// Use this for initialization
	void Start () {
		square = GameObject.CreatePrimitive (PrimitiveType.Cube);
		for (int i = 0; i < dimensionX; i++) {
			//for (int j = 0; 
		}
	}
	
	// Update is called once per frame
	void Update () {
					
	
	}
}
