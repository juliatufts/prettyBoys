using UnityEngine;
using System.Collections;

public class Boy : MonoBehaviour {

	public Sprite[] sprites;

	int index= 0;
	public void Leggings(){
		GetComponent<SpriteRenderer>().sprite = sprites[index];
		StartCoroutine(Dance ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Dance(){
		float step = 0;
		while (true){
			if (step % 20 == 0){
				transform.Rotate(Vector3.up, 180);
			}
			if (step % 10 == 0){
				GetComponent<SpriteRenderer>().sprite = sprites[index];
				index = (index + 1) % sprites.Length;
			}
			step++;
			yield return null;
		}
	}
}
