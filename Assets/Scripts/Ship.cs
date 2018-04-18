using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Ship : MonoBehaviour {

	public Transform				Mercury, Venus, Saturn;
	public float					accuracy;
	private NavMeshAgent			_navMeshAgent;
	bool	movingToMercury = false;
	//private GameObject				_actualShip;

	// Use this for initialization
	void Start () {
		_navMeshAgent = GetComponent<NavMeshAgent>();
		//_actualShip = transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingToMercury)
			_navMeshAgent.SetDestination (Mercury.position);
		print ("Nav Agent Destination: " + _navMeshAgent.destination);
		SetDestinations();
		//print ("Remaining Distance: " +_navMeshAgent.remainingDistance);
		//PrintPlanetsLocation();
	}

	void SetDestinations ()
	{
		if (Input.GetKey(KeyCode.Keypad1))
		{
			//print ("Moving to Mercury");
			movingToMercury = true;
			//_navMeshAgent.SetDestination (Mercury.position);
		}

		if (Input.GetKey(KeyCode.Keypad2))
		{
			//print ("Moving to Venus.");
			_navMeshAgent.SetDestination (Venus.position);
		}

		if (Input.GetKey(KeyCode.Keypad3))
		{
			//print ("Moving to Saturn.");
			_navMeshAgent.SetDestination (Saturn.position);
		}

	}

	void PrintPlanetsLocation ()
	{
		print ("Mercury: " + Mercury.position);
		print ("Venus: " + Venus.position);
	}
}
