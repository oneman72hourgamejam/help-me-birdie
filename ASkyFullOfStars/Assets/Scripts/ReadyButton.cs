using UnityEngine;
using System.Collections;

public class ReadyButton : MonoBehaviour {
	public Texture2D readyButtonTexture;
	public float readyButtonOffsetX;
	public float readyButtonOffsetY;
	public int setNativeWidth;
	public int setNativeHeight;

	public GUIStyle styleR;
	
	public AudioClip touchClip;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
		if(GUI.Button(new Rect(readyButtonOffsetX, readyButtonOffsetY, readyButtonTexture.width-20, readyButtonTexture.height), readyButtonTexture, styleR)) {
			Debug.Log ("Ready");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel("GameplayScene");
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	} 
}
