using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoyGenerator : MonoBehaviour {
	
	public GameObject boy;
	public GameObject plane;
	public int numBoys;	
	private List<GameObject> boys;
	
	// Use this for initialization
	void Start () {
		boys = new List<GameObject>();
		float xMin = plane.renderer.bounds.min.x + 5;
		float xMax = plane.renderer.bounds.max.x - 5;
		float yMin = plane.renderer.bounds.min.y;
		float yMax = plane.renderer.bounds.max.y - 5;
		
		for (int j = 0; j < numBoys; j++){
			float randomX = Random.Range(xMin, xMax);
			float randomY = Random.Range(yMin, yMax);

			var newBoy = GameObject.Instantiate(boy, new Vector3 (randomX, randomY, boy.transform.position.z), boy.transform.rotation) as GameObject;
				newBoy.transform.parent = transform;
				boys.Add(newBoy);
				newBoy.name = "Boy";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
