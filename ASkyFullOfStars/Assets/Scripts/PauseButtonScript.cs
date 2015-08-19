using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

	public Texture2D pauseButtonTexture;
	public float pauseButtonOffsetX;
	public float pauseButtonOffsetY;
	public int setNativeWidth;
	public int setNativeHeight;
	
	public GUIStyle stylePa;
	
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

	void Start () {
		pauseBg.SetActive (false);
		resumeBtn.SetActive (false);
		quitBtn.SetActive (false);

		//audioSourceWasPlayingBefore = false;

		audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
		if(GUI.Button(new Rect(pauseButtonOffsetX, pauseButtonOffsetY, pauseButtonTexture.width, pauseButtonTexture.height), pauseButtonTexture, stylePa)) {
			Debug.Log ("Pause");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			if(Time.timeScale != 0.0f){
				if(audioSource != null) {
					if(audioSource.isPlaying){
						continueSong = audioSource.time;
						audioSource.Stop ();
						audioSourceWasPlayingBefore = true;
					}
				}
				pauseBg.SetActive(true);
				resumeBtn.SetActive(true);
				quitBtn.SetActive(true);
				
				Time.timeScale = 0.0f;
			}
		}
	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}
