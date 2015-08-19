using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class PauseBtnScript : MonoBehaviour {

	public float x, y;
	public Texture2D resumeButtonTexture;
	public Texture2D quitButtonTexture;
	public Texture2D pauseButtonTexture;
	public float resumeButtonOffsetX;
	public float resumeButtonOffsetY;
	public float quitButtonOffsetX;
	public float quitButtonOffsetY;
	public float pauseButtonOffsetX;
	public float pauseButtonOffsetY;

	public int setNativeWidth;
	public int setNativeHeight;

	public GUIStyle style;
	
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
	
	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3 (x, y, 5));

		pauseBg.SetActive (false);
		resumeBtn.SetActive (false);
		quitBtn.SetActive (false);

		audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3 (x, y, 5));

	}

	void OnGUI (){
		if(GUI.Button(new Rect(pauseButtonOffsetX, pauseButtonOffsetY, pauseButtonTexture.width, pauseButtonTexture.height), pauseButtonTexture)) {
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
		if(GUI.Button(new Rect(resumeButtonOffsetX, resumeButtonOffsetY, resumeButtonTexture.width, resumeButtonTexture.height), resumeButtonTexture)) {
			Debug.Log ("Resume");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			if(audioSource != null) {
				if(audioSource.isPlaying){
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
		if(GUI.Button(new Rect(quitButtonOffsetX, quitButtonOffsetY, quitButtonTexture.width, quitButtonTexture.height), quitButtonTexture)) {
			Debug.Log ("Quit");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel("MainMenuGUI");
		}
	}




	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	}
}


















































