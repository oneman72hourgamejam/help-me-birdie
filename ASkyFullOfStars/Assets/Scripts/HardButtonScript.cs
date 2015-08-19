using UnityEngine;
using System.Collections;

public class HardButtonScript : MonoBehaviour {

	public Texture2D hardButtonTexture;
	public float hardButtonOffsetX;
	public float hardButtonOffsetY;
	public int setNativeWidth;
	public int setNativeHeight;
	
	public GUIStyle style;
	
	public AudioClip touchClip;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
		if(GUI.Button(new Rect(hardButtonOffsetX, hardButtonOffsetY, hardButtonTexture.width, hardButtonTexture.height), hardButtonTexture)) {
			Debug.Log ("Easy");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}
