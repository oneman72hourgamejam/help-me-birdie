using UnityEngine;
using System.Collections;

public class SpeedText : MonoBehaviour {

	public int fontSize;
	public CameraScript cameraScript;
	// Use this for initialization
	void Start () {
		SetFont ();
		UpdateScore ();
		cameraScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore ();
	}
	
	void UpdateScore() {
		guiText.text = "x" + (int)cameraScript.speed;
	}
	
	void SetFont() {
		guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
	}
}
