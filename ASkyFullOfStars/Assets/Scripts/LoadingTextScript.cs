using UnityEngine;
using System.Collections;

public class LoadingTextScript : MonoBehaviour {
	public float period;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > period) {
			Destroy(gameObject);
		}
		Color colorOfObject = guiText.material.color;
		float prop = (Time.time / period);
		colorOfObject.a = Mathf.Lerp (1, 0, prop);
		guiText.material.color = colorOfObject;
	}
}
