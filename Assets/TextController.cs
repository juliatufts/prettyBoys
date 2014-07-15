using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TextController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(stopText());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator stopText(){
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}
}
