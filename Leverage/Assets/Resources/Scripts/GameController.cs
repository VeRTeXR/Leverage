using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class  GameController : MonoBehaviour
{

	public GameObject Timer;
	public GameObject Player;
	public float MaxTimer;
	public float CurrentTimer;
	private bool _playerCompletedTheLevel;
	
	void Awake()
	{
		if(Timer == null)
			Timer = GameObject.Find("Timer");

		InitializeTimer();
	}

	private void InitializeTimer()
	{
		MaxTimer = 10;
		CurrentTimer = MaxTimer;
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
		
	}

	private void GameOver()
	{
		Debug.LogError("do something on game over");
		CurrentTimer = MaxTimer;
	}
}
