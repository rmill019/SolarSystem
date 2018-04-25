using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum E_Planets {Mercury = 1, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune };
public enum E_PlayerState {e_Idle, e_Moving, e_AtPlanet};

public class GameManager : MonoBehaviour {

	public static GameManager		S;
	public PlayerController			player;
	private int						previousPlanetIndex;
	public int						planetInput;
	// This array holds the number of days that it takes planets 1 - 8 to orbit the sun
	public static int[] 			daysToOrbit = new int[] { 12, 23, 37, 69, 433, 525, 815, 1000}; //{ 88, 225, 365, 687, 4333, 10756, 30687, 60190}
	public static string[]			planets = new string[8] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
	public Sprite[]					planetSprites;
	public Transform				Sun;

	public int 						fuel = 100;
	
	public float					timeToChoose;
	public bool						b_ActivateTimer;
	public bool						b_AwaitingInput = true;

	void Awake () {
		if (!S)
			S = this;
		else
			Destroy (this.gameObject);

		DontDestroyOnLoad (S);
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.KeypadEnter) && UIManager.S.missionStartText.gameObject.activeInHierarchy)
		{
			UIManager.S.missionStartText.gameObject.SetActive (false);
			DisplayTargetPlanet();
			UIManager.S.targetPlanetText.gameObject.SetActive (true);
			b_ActivateTimer = true;
		}

		if (b_ActivateTimer  && b_AwaitingInput)
		{
			planetInput = RecieveInput();
		}
	}

	void DisplayTargetPlanet ()
	{
		// Set the Texts Prefix.
		string defaultText = "Travel to: ";
		UIManager.S.targetPlanetText.text = defaultText;

		// Choose the new destination planet index, choose until we have a value not equal to the previous planet.
		int index;
		do {
			index  = Random.Range (0, 8);
		}while (index == previousPlanetIndex);

		previousPlanetIndex = index;

		// Choose the planet based on the index chosen and set the planets name to the Text Object to show the player.
		string planet = planets[index];
		UIManager.S.targetPlanetText.text += planet;
	}

	// Grab the planet that the player has chosen to go to
	int RecieveInput ()
	{
		int input = 0;

			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				input = 1;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Mercury");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				input = 2;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Venus");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				input = 3;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Earth");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad4))
			{
				input = 4;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Mars");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad5))
			{
				input = 5;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Jupiter");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad6))
			{
				input = 6;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Saturn");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				input = 7;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Uranus");
			}
			else if (Input.GetKeyDown(KeyCode.Keypad8))
			{
				input = 8;
				b_ActivateTimer = false;
				player.e_PlayerState = E_PlayerState.e_Moving;
				b_AwaitingInput = false;
				print ("Player chose: Neptune");
			}
		return input;
	}





}
