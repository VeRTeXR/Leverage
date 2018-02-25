using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class  GameController : MonoBehaviour
{

	public GameObject Timer;
	public GameObject Player;
	public float MaxTimer;
	public float CurrentTimer;
	private bool _playerCompletedTheLevel;
	private int _highScore;
	private int _currentSessionScore;
	private int _lastLevelReached;

	private static GameController _instance;
	public static GameController Instance
	{
		get { return _instance; }
	}
	
	void Awake()
	{
		if (_instance == null)
			_instance = this;
		else 
			Destroy(this);

		CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
		
		InitializeGameObject(); 
		InitializeTimer();
		InitializePlayerValue();
	}
	public int CurrentLevel { get; set; }
	private void InitializeGameObject()
	{
		if(Timer == null)
			Timer = GameObject.FindWithTag("Timer");

		if (Player == null)
			Player = GameObject.FindWithTag("Player");	
	}

	private void InitializeTimer()
	{
		MaxTimer = 10;
		CurrentTimer = MaxTimer;
	}

	private void InitializePlayerValue()
	{
//		CurrentLevel = 0;
//		_lastLevelReached = 0;
//		_currentSessionScore = 0; 
	}

	void Update ()
	{
		CurrentTimer = CurrentTimer - Time.deltaTime;
		Timer.GetComponent<Text>().text = CurrentTimer.ToString("F3");

		if (CurrentTimer <= 0)
			GameOver();

//		if (_playerCompletedTheLevel)
//		{
//			LevelComplete();
//			Debug.LogError("increment level do shit");
//		} 
	}

	public void LevelComplete()
	{
		CurrentLevel++;
		PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
		Debug.LogError(CurrentLevel);
		RestartLevel();
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void GameOver()
	{
		Debug.LogError("do something on game over");
		RestartLevel();
		CurrentTimer = MaxTimer;
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.DeleteKey("CurrentLevel");
	}
}
