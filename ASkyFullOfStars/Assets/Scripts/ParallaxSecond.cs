using UnityEngine;
using System.Collections;

public class ParallaxSecond : MonoBehaviour {
	public float ScreenSpeedX = 0.01f;
	public float ScreenSpeedY = 0.01f;
	public string tex;
	// Update is called once per frame
	void Update () {
		float offsetX = Time.time * ScreenSpeedX;
		float offsetY = Time.time * ScreenSpeedY;
		renderer.material.SetTextureOffset (tex, new Vector2(offsetX, offsetY));
	}
}
