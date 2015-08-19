using UnityEngine;
using System.Collections;

public class UnFadeScript : MonoBehaviour {
	public float period;
	//public string loadedLevelName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > period) {
			//Application.LoadLevel(loadedLevelName);
		}
		Color colorOfObject = guiText.material.color;
		float prop = (Time.time / period);
		colorOfObject.a = Mathf.Lerp (0, 1, prop);
		guiText.material.color = colorOfObject;
	}
}
