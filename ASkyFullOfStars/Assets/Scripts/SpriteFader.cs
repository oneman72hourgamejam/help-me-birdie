using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour {

	public float a;
	public float duration = 5.0f;
	public SpriteRenderer sprite;
	public float targetTime = 9.8f;

	void Start(){


	}

	void Update() {
		targetTime -= Time.deltaTime;
		a = Mathf.PingPong (Time.time / duration, 1.0f);
		sprite.color = new Color(1f, 1f, 1f, a);
		if(targetTime < a){
			Destroy(gameObject.GetComponent<SpriteFader>());
			sprite.color = new Color(1f, 1f, 1f, 0f);
		}
	}
}
