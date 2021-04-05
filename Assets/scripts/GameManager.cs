using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
	public GameObject skinPage;
	public GameObject bird;
	public AudioSource startSound;
	public AudioSource replaySound;
	public AudioSource skinPageSound;
	public int numLevels;
	public Text scoreText;

	enum PageState {
		None,
		Start,
		Countdown,
		GameOver,
		Skin
	}

	public int score = 0;

	public int level = 0;
	public int changeLevel = 0;

	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake() {
		if (Instance != null) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}

	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		level = 0;
		changeLevel = 0;
		gameOver = false;
	}

	void OnPlayerScored() {
		score++;
		scoreText.text = score.ToString();

		if (score%5 == 0)
        {
            changeLevel = 1;
			level = Random.Range(0, numLevels);
			Debug.Log("LEVEELL" + level);
		}else{
			changeLevel = 0;
		}
	}

	void OnPlayerDied() {
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore) {
			PlayerPrefs.SetInt("HighScore", score);
		}
		SetPageState(PageState.GameOver);
	}

	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				skinPage.SetActive(false);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				skinPage.SetActive(false);
				break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				skinPage.SetActive(false);
				break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				skinPage.SetActive(false);
				break;
			case PageState.Skin:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				skinPage.SetActive(true);
				break;
		}
	}
	
	public void ConfirmGameOver() {
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
		replaySound.Play();
	}

	public void StartGame() {
		SetPageState(PageState.Countdown);
		startSound.Play();
	}

	public void EnterSkinInventory()
    {
		SetPageState(PageState.Skin);
		skinPageSound.Play();

    }

	public void EnterStartPage()
    {
		SetPageState(PageState.Start);
		skinPageSound.Play();
	}
}
