using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
	private float _walkSpeed;
	private int _faceDirection;
	private float _walkCountdownInterval;
	private float _currentWalkCountdownInterval;
	private float _keyDownInterval;
	private float _currentKeyDownInterval;
	private bool _hasPlayerInputBeenProcessed;
	
	
	void Start ()
	{
		_walkSpeed = 10f;
		_walkCountdownInterval = 1f;
		_keyDownInterval = 0.25f;
		_currentKeyDownInterval = _keyDownInterval;
		_hasPlayerInputBeenProcessed = false;
	}
	
	void Update ()
	{
		ProcessingInput();
		MovePlayer();
		
		if (_hasPlayerInputBeenProcessed)
			HandlePlayerInputCooldownInterval();
		
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

	void ProcessingInput()
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
}
