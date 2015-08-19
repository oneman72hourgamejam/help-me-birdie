using UnityEngine;
using System.Collections;

public class OptionsDifficultiesScript : MonoBehaviour {
	public Texture2D easyButtonTexture;
	public float easyButtonOffsetX;
	public float easyButtonOffsetY;

	public Texture2D hardButtonTexture;
	public float hardButtonOffsetX;
	public float hardButtonOffsetY;

	public Texture2D mediumButtonTexture;
	public float mediumButtonOffsetX;
	public float mediumButtonOffsetY;

	public string Diff;

	public int setNativeWidth;
	public int setNativeHeight;

	public GUIStyle styleE;
	public GUIStyle styleM;
	public GUIStyle styleH;
	
	public AudioClip touchClip;

	public SingScript sign;
	// Use this for initialization
	void Start () {
		sign = GameObject.FindGameObjectWithTag ("Sign").GetComponent<SingScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckDifficulty ();
	}

	void OnGUI (){
		if(GUI.Button(new Rect(easyButtonOffsetX, easyButtonOffsetY, easyButtonTexture.width-20, easyButtonTexture.height), easyButtonTexture, styleE)) {
			Debug.Log ("Easy");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			GamePreferences.SetEasyDifficultyState(1);
			GamePreferences.SetMediumDifficultyState(0);
			GamePreferences.SetHardDifficultyState(0);
			sign.y = 0.621f;
		}

		if(GUI.Button(new Rect(mediumButtonOffsetX, mediumButtonOffsetY, mediumButtonTexture.width-20, mediumButtonTexture.height), mediumButtonTexture, styleM)) {
			Debug.Log ("Medium");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			GamePreferences.SetEasyDifficultyState(0);
			GamePreferences.SetMediumDifficultyState(1);
			GamePreferences.SetHardDifficultyState(0);
			sign.y = 0.492f;
		}

		if(GUI.Button(new Rect(hardButtonOffsetX, hardButtonOffsetY, hardButtonTexture.width-20, hardButtonTexture.height), hardButtonTexture, styleH)) {
			Debug.Log ("Hard");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			GamePreferences.SetEasyDifficultyState(0);
			GamePreferences.SetMediumDifficultyState(0);
			GamePreferences.SetHardDifficultyState(1);
			sign.y = 0.37f;
		}

	}
	
	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	} 

	void CheckDifficulty() {
		int easyDifficulty = GamePreferences.GetEasyDifficultyState();
		int mediumDifficulty = GamePreferences.GetMediumDifficultyState();
		int hardDifficulty = GamePreferences.GetHardDifficultyState();

		if(easyDifficulty == 1) {
			sign.y = 0.621f;
			Diff = GamePreferences.EasyDifficulty;
		}
		if(mediumDifficulty == 1) {
			sign.y = 0.492f;
			Diff = GamePreferences.MediumDifficulty;
		}
		if(hardDifficulty == 1) {
			sign.y = 0.37f;
			Diff = GamePreferences.HardDifficulty;
		}
	}
}





























































