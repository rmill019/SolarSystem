using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum E_Planets {Mercury = 0, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune };
public enum E_PlayerState {Idle, Moving, AtPlanet};

public class GameManager : MonoBehaviour {

	public static GameManager		S;
	public PlayerController			player;
	private int						previousPlanetIndex;
	public int						targetPlanetIndex;
	// This array holds the number of days that it takes planets 1 - 8 to orbit the sun
	public static int[] 			daysToOrbit = new int[] { 12, 23, 37, 69, 433, 525, 815, 1000}; //{ 88, 225, 365, 687, 4333, 10756, 30687, 60190}
	public static string[]			planets = new string[8] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
	public Sprite[]					planetSprites;
	public Transform				Sun;

	public int 						fuel = 100;
	
	public float					timeToChoose;
	public bool						b_ActivateTimer;
	public bool						b_AwaitingInput = true;
	public bool						b_GameActive = false;

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
			b_GameActive = true;
			UIManager.S.missionStartText.gameObject.SetActive (false);
			DisplayTargetPlanet();
			UIManager.S.targetPlanetText.gameObject.SetActive (true);
			b_ActivateTimer = true;
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
		targetPlanetIndex = index;

		// Choose the planet based on the index chosen and set the planets name to the Text Object to show the player.
		string planet = planets[index];
		UIManager.S.targetPlanetText.text += planet;

		// Setting the Planet Image of the canvas to white and making it fully transparent before assigning the corresponding planet image.
		Color white = Color.white;
		white.a = 1f;
		UIManager.S.planetImage.color = white;
		UIManager.S.planetImage.sprite = planetSprites[index];
	}

	public void DisplayChosenPlanet (int index)
	{
		string defaultText = "Traveling to: ";
		UIManager.S.chosenPlanetText.text = defaultText;
		UIManager.S.chosenPlanetText.text += planets[index];
		// If the chosen planet text is not active then set it to active (visible)
		if (!UIManager.S.chosenPlanetText.gameObject.activeInHierarchy)
			UIManager.S.chosenPlanetText.gameObject.SetActive (true);

		Color white = Color.white;
		white.a = 1f;
		UIManager.S.chosenPlanetImage.color = white;
		UIManager.S.chosenPlanetImage.sprite = planetSprites[index];
	}

	public void ResetTargetPlanetDisplay ()
	{
		UIManager.S.missionStartText.gameObject.SetActive (true);
		UIManager.S.targetPlanetText.gameObject.SetActive (false);
		UIManager.S.chosenPlanetText.gameObject.SetActive (false);
		UIManager.S.ClearPlanetImage();
		UIManager.S.ClearChosenPlanetImage();
	}


}
