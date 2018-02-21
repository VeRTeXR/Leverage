using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float _walkSpeed;
	private int _faceDirection;
	
	// Use this for initialization
	void Start ()
	{
		_walkSpeed = 1; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		ProcessingInput();

	}

	void ProcessingInput()
	{
		if (Input.GetKey("w"))
		{
				
		}
		if (Input.GetKey("a"))
		{
			
		}
		if (Input.GetKey("s"))
		{
			
		}
		if (Input.GetKey("d"))
		{
			
		}
	} 
}
