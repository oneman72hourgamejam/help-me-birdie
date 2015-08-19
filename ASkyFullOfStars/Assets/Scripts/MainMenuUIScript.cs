using UnityEngine;
using System.Collections;

public class MainMenuUIScript : MonoBehaviour {

	public Texture2D playButtonTexture;
	public Texture2D highScoreButtonTexture;
	public Texture2D optionsButtonTexture;
	public Texture2D quitButtonTexture;
	public Texture2D musicButtonOnTexture;
	public Texture2D musicButtonOffTexture;

	public float playButtonOffsetX;
	public float playButtonOffsetY;
	public float highScoreButtonOffsetX;
	public float highScoreButtonOffsetY;
	public float optionsButtonOffsetX;
	public float optionsButtonOffsetY;
	public float quitButtonOffsetX;
	public float quitButtonOffsetY;
	public float musicOnButtonOffsetX;
	public float musicOnButtonOffsetY;
	public float musicOffButtonOffsetX;
	public float musicOffButtonOffsetY;

	public int setNativeWidth;
	public int setNativeHeight;

	public bool isMusicOn;
	public GUIStyle styleStart;
	public GUIStyle styleQuit;
	public GUIStyle styleHigh;
	public GUIStyle styleOpt;
	public GUIStyle styleMOn;
	public GUIStyle styleMOff;

	public AudioClip touchClip;
	//public GameObject musicOn, musicOff;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		//musicOn = GameObject.FindGameObjectWithTag ("MusicOn");
		//musicOff = GameObject.FindGameObjectWithTag ("MusicOff");
		audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
		isMusicOn = false;
		IsTheGamePlayedForTheFirstTime ();
		CheckMusic ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		AutoResize (setNativeWidth, setNativeHeight);

		if(GUI.Button(new Rect(playButtonOffsetX, playButtonOffsetY, playButtonTexture.width-20, playButtonTexture.height), playButtonTexture, styleStart)) {
			Debug.Log ("Start");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			PlayerPrefs.SetInt(GamePreferences.GameStartedFromMainMenu, 1);
			Application.LoadLevel ("SplashScreen");

		}
		if(GUI.Button(new Rect(highScoreButtonOffsetX, highScoreButtonOffsetY, highScoreButtonTexture.width-20, highScoreButtonTexture.height), highScoreButtonTexture, styleHigh)) {
			Debug.Log ("HighScore");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel ("HighScoreScene");
		}
		if(GUI.Button(new Rect(optionsButtonOffsetX, optionsButtonOffsetY, optionsButtonTexture.width-20, optionsButtonTexture.height), optionsButtonTexture, styleOpt)) {
			Debug.Log ("Options");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel ("OptionsScene");
		}
		if(GUI.Button(new Rect(quitButtonOffsetX, quitButtonOffsetY, quitButtonTexture.width-20, quitButtonTexture.height), quitButtonTexture, styleQuit)) {
			Debug.Log ("About");
			AudioSource.PlayClipAtPoint(touchClip, transform.position);
			Application.LoadLevel ("AboutScene");
		}

		if (isMusicOn == true) {
			if(GUI.Button(new Rect(musicOnButtonOffsetX, musicOnButtonOffsetY, musicButtonOnTexture.width, musicButtonOnTexture.height), musicButtonOnTexture, styleMOn)) {
				isMusicOn = false;
				AudioSource.PlayClipAtPoint(touchClip, transform.position);
				TurnMusicOff();
			}
		}
		if (isMusicOn == false) {
			if(GUI.Button(new Rect(musicOffButtonOffsetX, musicOffButtonOffsetY, musicButtonOffTexture.width, musicButtonOffTexture.height), musicButtonOffTexture, styleMOff)) {
				isMusicOn = true;
				AudioSource.PlayClipAtPoint(touchClip, transform.position);
				TurnMusicOn();
			}
		}
	}

	public void AutoResize(int nativeWidth, int nativeHeight) {
		Vector2 aspectRatio = new Vector2 ((float)Screen.width / nativeWidth, (float)Screen.height / nativeHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (aspectRatio.x, aspectRatio.y, 1.0f));
	} 

	void IsTheGamePlayedForTheFirstTime() {
		
		if(!PlayerPrefs.HasKey("GamePlayed")) {
			
			// set the default difficulty medium (0 means false , 1 means true)
			GamePreferences.SetEasyDifficultyState(0);
			GamePreferences.SetMediumDifficultyState(1);
			GamePreferences.SetHardDifficultyState(0);
			
			// set the default highscore and coin score 0 for every difficulty
			GamePreferences.SetEasyDifficultyHighscore(0);
			GamePreferences.SetMediumDifficultyHighscore(0);
			GamePreferences.SetHardDifficultyHighscore(0);
			
			GamePreferences.SetEasyDifficultyCoinScore(0);
			GamePreferences.SetMediumDifficultyCoinScore(0);
			GamePreferences.SetHardDifficultyCoinScore(0);
			// the music is off by default
			GamePreferences.SetMusicState(0);
			
			
			// set the GamePlay arbitrary value to 1, which means next time when we check if this key exist it will be true
			// which means that the game has been opened and we dont need to set up our default values anymore
			PlayerPrefs.SetInt("GamePlayed", 1);
		}
		
	} // is the game played for the first time

	void CheckMusic() {
		//AudioSource audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
		// get the player prefs is the music on value
		int playMusic = GamePreferences.GetMusicState();;
		//int playMusic = 1;
		// if the value is 0 meaning false, check if the music is playing if its playing stop it, and deactivate MusicOn prefab button
		if (playMusic == 0) {
			
			if(audioSource.isPlaying) {
				audioSource.loop = false;
				audioSource.Stop();
				//musicOn.SetActive(false);
			} 

		} else if(playMusic == 1) {
			
			// if play music is 1 meaning true, check if the audio source is not playing then play the music and deactivate musicOff prefab button 
			if(!audioSource.isPlaying) {
				audioSource.loop = true;
				audioSource.Play();
				//musicOff.SetActive(false);
			} 
		}
		
	} // check music

	void TurnMusicOn() {
		
		if(!audioSource.isPlaying) {
			audioSource.loop = true;
			audioSource.Play();
			//musicOff.SetActive(false);
			//musicOn.SetActive(true);
		}	
		GamePreferences.SetMusicState(1);
	}

	void TurnMusicOff() {
		
		if(audioSource.isPlaying) {
			audioSource.loop = false;
			audioSource.Stop();
			//musicOn.SetActive(false);
			//musicOff.SetActive(true);
		}
		GamePreferences.SetMusicState(0);
	}
}




















































