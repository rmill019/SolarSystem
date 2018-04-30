using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager			S;

	[Header("UI Displayed Information")]
	public Slider					fuelSlider;
	public Slider					timerSlider;
	public Text						targetPlanetText;
	public Text						chosenPlanetText;
	public Text						missionStartText;
	public Image					planetImage;
	public Image					chosenPlanetImage;

	void Awake () {
		if (!S)
			S = this;
		else
			Destroy (this.gameObject);

		DontDestroyOnLoad (S);
	}

	// Use this for initialization
	void Start () {
		timerSlider.maxValue = GameManager.S.timeToChoose;
		timerSlider.value = GameManager.S.timeToChoose;
		
		targetPlanetText.gameObject.SetActive (false);
		chosenPlanetText.gameObject.SetActive (false);

		ClearPlanetImage();
		ClearChosenPlanetImage();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.S.b_ActivateTimer)
			timerSlider.value -= Time.deltaTime;
	}

	public void Refuel ()
	{
		fuelSlider.value = fuelSlider.maxValue;
	}

	public void ResetTimer ()
	{
		timerSlider.value = timerSlider.maxValue;
	}

	public void ClearPlanetImage()
	{
		// Assign the planetImage a color of white but set it's transparency to white
		Color white = Color.white;
		white.a = 0f;
		planetImage.color = white;
	}

	public void ClearChosenPlanetImage ()
	{
		// Assign the planetImage a color of white but set it's transparency to white
		Color white = Color.white;
		white.a = 0f;
		chosenPlanetImage.color = white;
	}
}
