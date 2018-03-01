using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float _walkSpeed;
	private int _faceDirection;
	private float _currentWalkCountdownInterval;
	private float _keyDownInterval;
	private float _currentKeyDownInterval;
	private bool _hasPlayerInputBeenProcessed;
	
	
	void Start ()
	{
		_walkSpeed = 3f * Mathf.Clamp(GameController.Instance.CurrentLevel, 1, 99);
		_keyDownInterval = 0.25f;
		_currentKeyDownInterval = _keyDownInterval;
		
	}
	
	void Update ()
	{
		ProcessingInput();
		MovePlayer();
		
		if (_hasPlayerInputBeenProcessed)
			HandlePlayerInputCooldownInterval();

		if (Input.GetKey(KeyCode.Space))
		{
			GameController.Instance.ResetPlayerPref();
		}
	}

	private void HandlePlayerInputCooldownInterval()
	{
		_currentKeyDownInterval -= Time.deltaTime;
		if (_currentKeyDownInterval <= 0)
		{
			_hasPlayerInputBeenProcessed = false;
			_currentKeyDownInterval = _keyDownInterval;
		}
	}

	private void MovePlayer()
	{
		transform.localPosition = transform.localPosition + transform.right * _walkSpeed * Time.deltaTime;
	}

	private void ProcessingInput()
	{ 
		if(_hasPlayerInputBeenProcessed) return;
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
		{
			transform.Rotate(Vector3.forward * 90);
			_hasPlayerInputBeenProcessed = true;
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
		{
			transform.Rotate(-Vector3.forward * 90);
			_hasPlayerInputBeenProcessed = true;
		}
	}

	private void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.CompareTag("Level"))
			transform.Rotate(Vector3.forward * 90);

		if (c.gameObject.CompareTag("Exit"))
		{
			GameController.Instance.LevelComplete();
		}
		
	}
}
