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
	public GameObject				missionStartPanel;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.S.b_ActivateTimer)
			timerSlider.value -= Time.deltaTime;
	}
}
