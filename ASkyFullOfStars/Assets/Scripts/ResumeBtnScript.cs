using UnityEngine;
using System.Collections;

public class ResumeBtnScript : MonoBehaviour {

	public Texture2D resumeButtonTexture;
	public float resumeButtonOffsetX;
	public float resumeButtonOffsetY;
	public int setNativeWidth;
	public int setNativeHeight;
	
	public GUIStyle styleR;
	
	public AudioClip touchClip;

	[SerializeField]
	private GameObject pauseBg;
	
	[SerializeField]
	private GameObject resumeBtn;
	
	[SerializeField]
	private GameObject quitBtn;
	
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
		if(GUI.Button(new Rect(resumeButtonOffsetX, resumeButtonOffsetY, resumeButtonTexture.width-20, resumeButtonTexture.height), resumeButtonTexture, styleR)) {
			Debug.Log ("Resume");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			if(audioSource != null) {
				if(audioSourceWasPlayingBefore){
					audioSource.time = continueSong;
					audioSource.Play ();
					audioSourceWasPlayingBefore = false;
				}
			}
			Time.timeScale = 1.0f;
			pauseBg.SetActive(false);
			resumeBtn.SetActive(false);
			quitBtn.SetActive(false);
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}
