using UnityEngine;
using System.Collections;

public class MainMenuControllerScript : MonoBehaviour {
	public GameObject musicOn, musicOff;
	public AudioClip touchClip;

	// Use this for initialization
	void Start () {
		musicOn = GameObject.FindGameObjectWithTag ("MusicOn");
		musicOff = GameObject.FindGameObjectWithTag ("MusicOff");
		musicOn.SetActive(false);
	}



	// Update is called once per frame
	void Update () {
		ChechForTouch();
	}



	void ChechForTouch () {
		if(Input.touchCount > 0) {
			Touch t = Input.touches[0];
			if(t.phase == TouchPhase.Began) {
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
				Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
				Collider2D hit = Physics2D.OverlapPoint(touchPos);
				if(hit)
						Debug.Log ("You pressed " + hit.tag);
			}
		}
	}
}
