using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	private GameObject player;
	private Vector3 pos;
	private Quaternion rot;

	public GameObject customSpawnPoint;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		pos = player.transform.position;
		rot = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			if(customSpawnPoint != null){
				player.transform.position = customSpawnPoint.transform.position;
			} else {
				player.transform.position = pos;
				player.transform.rotation = rot;
			}
		}
	}
}
