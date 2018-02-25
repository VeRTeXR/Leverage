using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float _walkSpeed;
	private int _faceDirection;
	private float _walkCountdownInterval;
	private float _currentWalkCountdownInterval;
	
	
	void Start ()
	{
		_walkSpeed = 10f;
		_walkCountdownInterval = 1f;
	}
	
	void Update ()
	{
		ProcessingInput();
		_currentWalkCountdownInterval--;

		if (_currentWalkCountdownInterval <= 0)
		{
			MovePlayer();
			_currentWalkCountdownInterval = _walkCountdownInterval;
		} 
	}

	private void MovePlayer()
	{
		transform.localPosition = transform.localPosition + transform.up * _walkSpeed * Time.deltaTime;
	}

	void ProcessingInput()
	{ 
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
			transform.Rotate(Vector3.forward * 90 * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
			transform.Rotate(-Vector3.forward * 90 * Time.deltaTime);
	} 
}
