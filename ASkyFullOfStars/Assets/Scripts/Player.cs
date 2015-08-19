using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 8.0f;  // the speed by which the player moves
    public float maxVelocity = 3.0f;    // maximum velocity of the player

    private Animator animator;  // players animator for animation controlce to the camera script

    public AudioClip coinClip;
    public AudioClip lifeClip;

    public static int lifeCount;    // life counter
    public static int coinCount;    // coin counter
    public static int scoreCount;   // score counter
    public bool countPoints;

    public Vector3 lastPosition;

    public Vector3 boundaries;

	private CameraScript cameraScript;

	private int easyDifficulty;
	private int mediumDifficulty;
	private int hardDifficulty;

	[SerializeField]
	private GameObject ready;

	[SerializeField]
	private GameObject fader;

	private GamePlayFadeScript fadeScript;

	private bool isTheGameStartedFromBegining;

	[SerializeField]
	private GameObject showEndScore;

	[SerializeField]
	private GameObject endScoreText;

	[SerializeField]
	private GameObject endCoinText;

	[SerializeField]
	private GameObject endSpeedText;

	[SerializeField]
	private GameObject speedText;

	[SerializeField]
	private GameObject pauseBtn;

	private int countTouches;

	public GameObject fade1;
	public GameObject fade2;

	// Use this for initialization
	void Start () {

		countTouches = 0;
		pauseBtn.SetActive (true);
        animator = GetComponent<Animator> ();   // getting the animator reference

        
        lastPosition = transform.position;

        boundaries = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)); // getting player boundaries

		cameraScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraScript> ();
		fadeScript = fader.GetComponent<GamePlayFadeScript> ();

		fade1.SetActive (false);
		fade2.SetActive (false);
		showEndScore.SetActive (false);
		endScoreText.SetActive (false);
		endCoinText.SetActive (false);
//		diffText.SetActive (false);
		endSpeedText.SetActive (false);


		easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		hardDifficulty = GamePreferences.GetHardDifficultyState ();

		IsTheGameStartedFromMainMenu ();
		IsTheGameResumedAfterPlayerDied ();

		Time.timeScale = 0.0f;
		isTheGameStartedFromBegining = true;

		fader.SetActive (false);


    }

	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 1.0f){
	   		PlayerWalkKeyboard ();
       		
			if(countTouches > 3) {
				SetScore ();
			}
		}
    }

    void LateUpdate() {
		if(isTheGameStartedFromBegining){
			if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
           		Time.timeScale = 1.0f;
            	countPoints = true;
				ready.SetActive(false);
				isTheGameStartedFromBegining = false;
        	}
		}
        CheckBounds ();

		//if(easyDifficulty == 1 && scoreCount > 100 ){
		//	fade1.SetActive(true);
			//Application.LoadLevel("WinScene");
		//}
		//if(easyDifficulty == 1 && scoreCount > 200 ){
		//	fade2.SetActive(true);
			//Application.LoadLevel("WinScene");
		//}
		if(easyDifficulty == 1 && scoreCount > 50000 || coinCount > 500){
			Application.LoadLevel("WinScene");
		}
		if(mediumDifficulty == 1 && scoreCount > 30000 || coinCount > 300){
			Application.LoadLevel("WinScene");
		}
		if(hardDifficulty == 1 && scoreCount > 10000 || coinCount > 100){
			Application.LoadLevel("WinScene");
		}
    }

	void IsTheGameStartedFromMainMenu() {
		
		int isTheGameStartedFromMainMenu = PlayerPrefs.GetInt (GamePreferences.GameStartedFromMainMenu);
		
		if (isTheGameStartedFromMainMenu == 1) {
			
			if(easyDifficulty == 1) {
				cameraScript.SetEasySpeed();
			}
			
			if(mediumDifficulty == 1) {
				cameraScript.SetMediumSpeed();
			}
			
			if(hardDifficulty == 1) {
				cameraScript.SetHardSpeed();
			}
			
			scoreCount = 0;	// score is 0
			coinCount = 0;  // coin score is 0
			lifeCount = 2;
			
			PlayerPrefs.SetInt(GamePreferences.GameStartedFromMainMenu, 0);
			
		}
		
	}
	
	// check if the game is resumed after player died
	void IsTheGameResumedAfterPlayerDied() {
		
		int gameResumedAfterPlayerDied = PlayerPrefs.GetInt (GamePreferences.GameResumedAfterPlayerDied);
		
		if (gameResumedAfterPlayerDied == 1) {
			
			scoreCount = PlayerPrefs.GetInt(GamePreferences.CurrentScore);
			coinCount = PlayerPrefs.GetInt(GamePreferences.CurrentCoinScore);
			lifeCount = PlayerPrefs.GetInt(GamePreferences.CurrentLifes);
			
			
			PlayerPrefs.SetInt(GamePreferences.GameResumedAfterPlayerDied, 0);
		}
		
	}

    void CheckBounds() {

        // check if the players x is greather than the x of the boundaries, if its true set the players x to be boundaries x
        if (transform.position.x > boundaries.x) {
            Vector3 temp = transform.position;
            temp.x = boundaries.x;
            transform.position = temp;
        }

        // check if the players x is less than the x of the boundaries, if its true set the players x to be negative boundaries x
        if (transform.position.x < (-boundaries.x)) {
            Vector3 temp = transform.position;
            temp.x = -boundaries.x;
            transform.position = temp;
        }

    }

    void SetScore() {

        // if countPoints is true then count points
        if (countPoints) {

            if(transform.position.y < lastPosition.y) {
                scoreCount++;
            }

            lastPosition = transform.position;
        }

    }

    void PlayerWalkKeyboard (){
		countTouches++;
        // force by which we will push the player
        float force = 0.0f;
        // the players velocity
        float velocity = Mathf.Abs (rigidbody2D.velocity.x);

        // getting the input from the player
        float h = Input.GetAxis ("Horizontal");

        // checking if the player is moving right
	
		if (h > 0 ) {

            // if the velocity of the player is less than the maxVelocity
            if(velocity < maxVelocity)
                force = speed;

            // turn the player to face right
            Vector3 scale = transform.localScale;
            scale.x = 0.5f;
            transform.localScale = scale;

            // animate the walk
            animator.SetInteger("Walk", 1);

            // check if the player is moving left
        }  else if(h < 0) {

            // if the velocity of the player is less than the maxVelocity
            if(velocity < maxVelocity)
                force = -speed;

            // turn the player to face left
            //Vector3 scale = transform.localScale;
            //scale.x = -0.5f;
            //transform.localScale = scale;

            // animate the walk
            animator.SetInteger("Walk", 1);

        }
		
        // if the player is not moving set the animation to idle
        if(h == 0)
            animator.SetInteger("Walk", 1);

        // add force to rigid body to move the player
        rigidbody2D.AddForce (new Vector2 (force, 0));

    }

    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "Coin") {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip, target.transform.position);
            target.gameObject.SetActive (false);
        }

        if (target.tag == "Life") {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip, target.transform.position);
            target.gameObject.SetActive (false);

        }

        if (target.tag == "Boundary") {
            Debug.Log("OUT!");
            cameraScript.moveCamera = false;
            countPoints = false;
            CheckGameStatus();
        }

		if (target.tag == "Deadly"){
			cameraScript.moveCamera = false;
			countPoints = false;
			CheckGameStatus();
		}
    }

	void CheckGameStatus() {
		
		// remove the player from scene by changing his x y position, and then decrement lifes
		Vector3 temp = transform.position;
		temp.x = 100;
		temp.y = 100;
		transform.position = temp;
		lifeCount--;
		
		// if lifes are less than 0 end the game, get the coins and score and check it with the highscore
		if(lifeCount < 0) {
			
			if(easyDifficulty == 1) {
				
				int currentHighscore = GamePreferences.GetEasyDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetEasyDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetEasyDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) {
					GamePreferences.SetEasyDifficultyCoinScore(coinCount);
				}

				
				
			}   // easy difficulty
			
			if(mediumDifficulty == 1) {
				
				int currentHighscore = GamePreferences.GetMediumDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetMediumDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetMediumDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) {
					GamePreferences.SetMediumDifficultyCoinScore(coinCount);
				}
				
			}   // mediumDifficulty
			
			if(hardDifficulty == 1) {
				
				int currentHighscore = GamePreferences.GetHardDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetHardDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetHardDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) {
					GamePreferences.SetHardDifficultyCoinScore(coinCount);
				}
				
			}   // hard difficulty
			
			// set the life count to be zero so that it wont display -1 on screen
			lifeCount = 0;
			//Application.LoadLevel ("MainMenuGUI");
			StartCoroutine(ReloadMainMenuAfterPlayerHasNoMoreLifesLeft());
			
			
			// the player has still lifes left to continue the game
		}   else {
			
			PlayerPrefs.SetInt(GamePreferences.CurrentScore, scoreCount);
			PlayerPrefs.SetInt(GamePreferences.CurrentCoinScore, coinCount);
			PlayerPrefs.SetInt(GamePreferences.CurrentLifes, lifeCount);
			
			PlayerPrefs.SetInt(GamePreferences.GameResumedAfterPlayerDied, 1);
			//Application.LoadLevel ("GameplayScene");
			StartCoroutine(ReloadGame());
			
			
		}

		
	}
	IEnumerator ReloadGame() {
		
		// set the fader to be active because we need it now
		fader.SetActive (true);
		pauseBtn.SetActive (false);
		// wait half a second before fading
		yield return new WaitForSeconds(0.5f);
		
		// fade
		float fadeTime = fadeScript.BeginFade (1);

		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (Application.loadedLevel);
	
	}
	
	// reload main menu after player has no more lifes left
	IEnumerator ReloadMainMenuAfterPlayerHasNoMoreLifesLeft() {
		pauseBtn.SetActive (false);
		// activate the end showing score gameobjects
		showEndScore.SetActive (true);
		endScoreText.SetActive (true);
		endCoinText.SetActive (true);
//		diffText.SetActive (true);
		endSpeedText.SetActive (true);

		endScoreText.guiText.text = "" + scoreCount;
		endCoinText.guiText.text = "x" + coinCount;
		//diffText.guiText.text = "" + OptionsDifficultiesScript.Diff;
		endSpeedText.guiText.text = "x" + (int)cameraScript.speed;

		// wait 3 seconds for the player to see the score
		yield return new WaitForSeconds(3);
		
		// activate fader
		fader.SetActive (true);
		
		// set MainMenuOpenedFromGameplay to 1, so that the fader in MainMenuScene will fade smoothly
		PlayerPrefs.SetInt (GamePreferences.MainMenuOpenedFromGameplay, 1);

		//yield return new WaitForSeconds(1);
		// fade
		float fadeTime = fadeScript.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		//fadeScript.BeginFade (1);
		Application.LoadLevel ("MainMenuGUI");
	}
}


































