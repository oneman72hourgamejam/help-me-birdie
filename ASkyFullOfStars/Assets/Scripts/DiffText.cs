using UnityEngine;
using System.Collections;

public class DiffText : MonoBehaviour {

	public int fontSize;
	//public OptionsDifficultiesScript diff;
	// Use this for initialization
	void Start () {
		SetFont ();
		UpdateScore ();
		//diff = GetComponent<OptionsDifficultiesScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore ();
	}
	
	void UpdateScore() {
		//guiText.text = "" + diff.Diff;
	}
	
	void SetFont() {
		guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
	}
}
