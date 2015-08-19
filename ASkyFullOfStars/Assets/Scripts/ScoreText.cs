using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

    public int fontSize;

    // Use this for initialization
    void Start () {
       SetFont ();
       UpdateScore ();
    }

    // Update is called once per frame
    void Update () {
       UpdateScore ();
    }

    void UpdateScore() {
        guiText.text = "" + Player.scoreCount;
    }

    void SetFont() {
        guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
    }
}
