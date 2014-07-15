using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;
	private bool playerInBounds;
	
	void Start () {
		offset = transform.position;
		playerInBounds = true;
	}
	
	void LateUpdate () {
		if(playerInBounds){
			transform.position = player.transform.position + offset;
		}
	}
}
