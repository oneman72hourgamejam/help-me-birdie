using UnityEngine;
using System.Collections;

public class SpriteDestroy : MonoBehaviour {
	
	public float targetTime = 5.0f;
	public float a = 0.0f;
	public GameObject fade2;
	void Start(){
		if(a > targetTime){
			fade2.SetActive(false);
			//Destroy(gameObject.GetComponent<SpriteFader>());
			Destroy(gameObject.GetComponent<SpriteRenderer>());
		}
	}
	
	void FixedUpdate() {
		targetTime -= Time.deltaTime;
		if(targetTime == 1.0f){
			//fade2.SetActive(true);
			Destroy(gameObject.GetComponent<SpriteDestroy>());
			//Destroy(gameObject.GetComponent<SpriteRenderer>());
		}

	}
}
