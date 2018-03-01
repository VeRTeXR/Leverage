using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	void Start()
	{
		target = GameController.Instance.Player.GetComponent<Transform>();
	}
	void Update ()
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
//	private Transform _playerTransform; 
//	void Start ()
//	{
//		_playerTransform = GameController.Instance.Player.GetComponent<Transform>();
//	}
//
//	void Update()
//	{
//		transform.localPosition = _playerTransform.localPosition + new Vector3(0, 0, -30);
//	}
	
}
