using UnityEngine;
using System.Collections;

public class CoinText : MonoBehaviour {

    public int fontSize;

    // Use this for initialization
    void Start () {
       SetFont ();
       UpdateCoins ();
    }

    // Update is called once per frame
    void Update () {
       UpdateCoins ();
    }

    void UpdateCoins() {
        guiText.text = "x" + Player.coinCount;
    }

    void SetFont() {
        guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
    }
}
