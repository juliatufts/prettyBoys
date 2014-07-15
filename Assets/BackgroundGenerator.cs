using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject couch;
	public GameObject table;
	public GameObject cup;
	public GameObject bottle;
	public GameObject plane;
	public int numCouch;
	public int numTable;
	
	// Use this for initialization
	void Start () {
		float xMin = plane.renderer.bounds.min.x + 5;
		float xMax = plane.renderer.bounds.max.x - 5;
		float yMin = plane.renderer.bounds.min.y;
		float yMax = plane.renderer.bounds.max.y - 5;
		
		for (int j = 0; j < numCouch; j++){
			float randomX = Random.Range(xMin, xMax);
			float randomY = Random.Range(yMin, yMax);
			
			var newCouch = GameObject.Instantiate(couch, new Vector3 (randomX, randomY, couch.transform.position.z), couch.transform.rotation) as GameObject;
			newCouch.transform.parent = transform;
			newCouch.name = "Couch";
		}

		for (int j = 0; j < numTable; j++){
			float randomX = Random.Range(xMin, xMax);
			float randomY = Random.Range(yMin, yMax);
			
			var newTable = GameObject.Instantiate(table, new Vector3 (randomX, randomY, table.transform.position.z), table.transform.rotation) as GameObject;
			newTable.transform.parent = transform;
			newTable.name = "Couch";

			var newCup = GameObject.Instantiate(cup, new Vector3 (randomX, randomY + 0.15f, table.transform.position.z), table.transform.rotation) as GameObject;
			newCup.transform.parent = transform;
			newCup.name = "Cup";

			var newBottle = GameObject.Instantiate(bottle, new Vector3 (randomX + 0.13f, randomY + 0.2f, table.transform.position.z), table.transform.rotation) as GameObject;
			newBottle.transform.parent = transform;
			newBottle.name = "Bottle";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
