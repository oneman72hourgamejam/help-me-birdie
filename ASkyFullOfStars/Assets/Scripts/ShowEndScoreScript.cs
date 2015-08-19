using UnityEngine;
using System.Collections;

public class ShowEndScoreScript : MonoBehaviour {

	public int fontSize;

	// Use this for initialization
	void Start () {
		SetFont ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetFont() {
		guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
	}
}
