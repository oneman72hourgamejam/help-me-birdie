using UnityEngine;
using System.Collections;

public class ParallaxBasic : MonoBehaviour {
	public float ScreenSpeedX = 0.01f;
	public float ScreenSpeedY = 0.01f;
	
	// Update is called once per frame
	void Update () {
		float offsetX = Time.time * ScreenSpeedX;
		float offsetY = Time.time * ScreenSpeedY;
		renderer.material.SetTextureOffset ("_MainTex", new Vector2(offsetX, offsetY));
	}
}
