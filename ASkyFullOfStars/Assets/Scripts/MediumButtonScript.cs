using UnityEngine;
using System.Collections;

public class MediumButtonScript : MonoBehaviour {

	public Texture2D mediumButtonTexture;
	public float mediumButtonOffsetX;
	public float mediumButtonOffsetY;
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
		if(GUI.Button(new Rect(mediumButtonOffsetX, mediumButtonOffsetY, mediumButtonTexture.width, mediumButtonTexture.height), mediumButtonTexture)) {
			Debug.Log ("Easy");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}
