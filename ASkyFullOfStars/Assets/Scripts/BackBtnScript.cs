using UnityEngine;
using System.Collections;

public class BackBtnScript : MonoBehaviour {

	public Texture2D backButtonTexture;
	public float backButtonOffsetX;
	public float backButtonOffsetY;
	/*public float musicOnButtonOffsetX;
	public float musicOnButtonOffsetY;
	public float musicOffButtonOffsetX;
	public float musicOffButtonOffsetY;
	public Texture2D musicButtonOnTexture;
	public Texture2D musicButtonOffTexture;*/
	public int setNativeWidth;
	public int setNativeHeight;
	
	//public bool isMusicOn;
	public GUIStyle styleB;
	
	public AudioClip touchClip;
	//public GameObject btn;
	//public Animator animator;
	// Use this for initialization
	void Start () {
		//isMusicOn = false;
		//animator = btn.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI (){
		if(GUI.Button(new Rect(backButtonOffsetX, backButtonOffsetY, backButtonTexture.width, backButtonTexture.height), backButtonTexture, styleB)) {
			Debug.Log ("Back");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel("MainMenuGUI");
			//animator.Play("BackBtn");
		}


		/*if (isMusicOn == true) {
			if(GUI.Button(new Rect(musicOnButtonOffsetX, musicOnButtonOffsetY, musicButtonOnTexture.width, musicButtonOnTexture.height), musicButtonOnTexture)) {
				isMusicOn = false;
				AudioSource.PlayClipAtPoint(touchClip, transform.position);
			}
		}
		if (isMusicOn == false) {
			if(GUI.Button(new Rect(musicOffButtonOffsetX, musicOffButtonOffsetY, musicButtonOffTexture.width, musicButtonOffTexture.height), musicButtonOffTexture)) {
				isMusicOn = true;
				AudioSource.PlayClipAtPoint(touchClip, transform.position);
			}
		}*/
	}

	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	} 
}




























