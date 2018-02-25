using System.Resources;
using UnityEngine;
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
	private int _currentLevel;
	private int _lastLevelReached;

	public static GameController Instance = null; 
	
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		
		InitializeGameObject(); 
		InitializeTimer();
		InitializePlayerValue();
	}

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
		_currentLevel = 0;
		_lastLevelReached = 0;
		_currentSessionScore = 0; 
	}

	void Update ()
	{
		CurrentTimer = CurrentTimer - Time.deltaTime;
		Timer.GetComponent<Text>().text = CurrentTimer.ToString("F3");

		if (CurrentTimer <= 0)
			GameOver();

		if (_playerCompletedTheLevel)
		{
			LevelComplete();
			Debug.LogError("increment level do shit");
		} 
	}

	private void LevelComplete()
	{
		_currentLevel++;
	}

	private void GameOver()
	{
		Debug.LogError("do something on game over");
		CurrentTimer = MaxTimer;
	}
}
