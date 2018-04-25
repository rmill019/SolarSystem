using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPlayer : MonoBehaviour {

	private NavMeshAgent		agent;
	public List<Transform>		planets;
	public float 				accuracy;

	public E_PlayerState		playerState;

	private bool				b_IsMoving = false;
	private int					chosenPlanetIndex = -1;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		playerState = E_PlayerState.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
		print ("Planet Index: " + chosenPlanetIndex);
		ChoosePlanetDestination();

		if (b_IsMoving && chosenPlanetIndex != -1)
		{
			MoveTo (chosenPlanetIndex);
		}
	}

	void MoveTo (int index)
	{
			agent.SetDestination (planets[index].position);
			print ("Moving to " + planets[index].gameObject.name);
	}

	void ChoosePlanetDestination ()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1)) 
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 1; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 2; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 3; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad5)) 
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad6))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 5; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad7))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 6; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 7; 
		}
	}
}
