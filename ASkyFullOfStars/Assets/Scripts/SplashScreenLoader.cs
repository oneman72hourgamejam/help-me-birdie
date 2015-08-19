using UnityEngine;
using System.Collections;

public class SplashScreenLoader : MonoBehaviour {
	public float delayTime = 10;
	public bool done = false;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = delayTime;
		StartCoroutine ("SomeFunction");
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer > 0)
			return;
		if (done)
		Application.LoadLevel ("GamePlayScene");
	}
	IEnumerator SomeFunction(){
		yield return null;
		done = true;
	}
}
