using UnityEngine;
using System.Collections;

public class LifeText : MonoBehaviour {

    public int fontSize;

	// Use this for initialization
	void Start () {
	   SetFont ();
       UpdateLifes ();
	}

	// Update is called once per frame
	void Update () {
	   UpdateLifes ();
	}

    void UpdateLifes() {
        guiText.text = "x" + Player.lifeCount;
    }

    void SetFont() {
        guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
    }
}
