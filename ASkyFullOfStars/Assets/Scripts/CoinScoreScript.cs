using UnityEngine;
using System.Collections;

public class CoinScoreScript : MonoBehaviour {
	public int fontSize;
	// Use this for initialization
	void Start () {
		SetFont ();
		CheckDifficultyAndSetScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetFont () {
		guiText.fontSize = Mathf.Min (Screen.width, Screen.height) / fontSize;
	}

	void CheckDifficultyAndSetScore() {
		int easyDifficulty = GamePreferences.GetEasyDifficultyState();
		int mediumDifficulty = GamePreferences.GetMediumDifficultyState();
		int hardDifficulty = GamePreferences.GetHardDifficultyState();
		if(easyDifficulty == 1) {
			guiText.text = GamePreferences.GetEasyDifficultyHighscore().ToString ();
		}
		if(mediumDifficulty == 1) {
			guiText.text = GamePreferences.GetMediumDifficultyHighscore().ToString ();
		}
		if(hardDifficulty == 1) {
			guiText.text = GamePreferences.GetHardDifficultyHighscore().ToString ();
		}
	}
}































