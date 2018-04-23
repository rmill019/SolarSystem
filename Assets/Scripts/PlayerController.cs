using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public E_PlayerState			e_PlayerState;

	// Movement functions
	public float			period = 2.0f;
	public float			maxHeight = .25f;
	public float			maxLateral = 0.0005f;
	public float			angle;


	// Use this for initialization
	void Start () {
		e_PlayerState = E_PlayerState.e_Idle;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (e_PlayerState == E_PlayerState.e_Idle)
		{
			//print ("Idling");
			IdleMovement();
		}
		
	}

	// Needs work
	void IdleMovement()
	{
		float phase = Mathf.Sin (Time.time / period);
		float newHeight = phase * maxHeight;
		float newLateral = phase * maxLateral;
		float newAngle = phase * angle;

		
		Vector3 pos = new Vector3 (transform.position.x - newLateral, transform.position.y + newHeight, transform.position.z);
		transform.position = pos;
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x - newAngle, transform.localEulerAngles.y, transform.localEulerAngles.z + newAngle);
	}
}
