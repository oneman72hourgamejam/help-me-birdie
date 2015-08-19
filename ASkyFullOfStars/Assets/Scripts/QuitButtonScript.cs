using UnityEngine;
using System.Collections;

public class QuitButtonScript : MonoBehaviour {

	public Texture2D quitButtonTexture;
	public float quitButtonOffsetX;
	public float quitButtonOffsetY;
	public int setNativeWidth;
	public int setNativeHeight;
	
	public GUIStyle styleEx;
	
	public AudioClip touchClip;

	private AudioSource audioSource;
	
	private bool audioSourceWasPlayingBefore;
	
	private float continueSong;
	
	void Awake () {
		audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
		if(GUI.Button(new Rect(quitButtonOffsetX, quitButtonOffsetY, quitButtonTexture.width-20, quitButtonTexture.height), quitButtonTexture, styleEx)) {
			Debug.Log ("Quit");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			if (audioSource != null) {
				
				if(audioSourceWasPlayingBefore) {
					audioSource.time = continueSong;
					audioSource.Play();
					audioSourceWasPlayingBefore = false;
				}
				
			}
			Application.LoadLevel("MainMenuGUI");
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}
