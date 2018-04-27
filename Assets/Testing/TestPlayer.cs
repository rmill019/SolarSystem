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

		if (GameManager.S.b_GameActive)
			ChoosePlanetDestination();

		if (playerState == E_PlayerState.Moving && chosenPlanetIndex != -1)
		{
			MoveTo (chosenPlanetIndex);
		}
	}

	void MoveTo (int index)
	{
			agent.SetDestination (planets[index].position);
			print ("Moving to " + planets[index].gameObject.name);
	}

	// Once we Choose a destination we set the Player Ship to moving, activate the moving bool
	// deactivate the Timer and set the chosenPlanetIndex for comparison later on
	void ChoosePlanetDestination ()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1)) 
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 1; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 2; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 3; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad5)) 
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad6))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 5; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad7))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 6; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			GameManager.S.b_ActivateTimer = false;
			//b_IsMoving = true;
			playerState = E_PlayerState.Moving;
			chosenPlanetIndex = 7; 
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		// If we have reached a planet and it is the same planet chosen as the
		// target Destination then Refuel the ship
		if (coll.gameObject.GetComponent<Planet>())
		{
			Planet planet = coll.gameObject.GetComponent<Planet>();
			if ((int)planet.e_Planet == GameManager.S.targetPlanetIndex)
			{
				print ("Nigga we made it");
				UIManager.S.Refuel();
				UIManager.S.ResetTimer();
			}

			// Prompt the player to Press Enter to choose their next destination
			GameManager.S.ResetTargetPlanetDisplay();
			UIManager.S.ResetTimer();
		}
		else
			return;

	}
}
