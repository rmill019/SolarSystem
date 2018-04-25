using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPlayer : MonoBehaviour {

	private NavMeshAgent		agent;
	public List<Transform>		planets;
	public float 				accuracy;

	private bool				b_IsMoving = false;
	private int					planetIndex = -1;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		print ("Planet Index: " + planetIndex);
		ChoosePlanetDestination();

		if (b_IsMoving && planetIndex != -1)
		{
			MoveTo (planetIndex);
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
			planetIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			b_IsMoving = true;
			planetIndex = 1; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			b_IsMoving = true;
			planetIndex = 2; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			b_IsMoving = true;
			planetIndex = 3; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad5)) 
		{
			b_IsMoving = true;
			planetIndex = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad6))
		{
			b_IsMoving = true;
			planetIndex = 5; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad7))
		{
			b_IsMoving = true;
			planetIndex = 6; 
		}
		else if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			b_IsMoving = true;
			planetIndex = 7; 
		}
	}
}
