using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Planets {e_Mercury = 0, e_Venus, e_Earth, e_Mars, e_Jupiter, e_Saturn, e_Uranus, e_Neptune };
public class GameManager : MonoBehaviour {

	public static GameManager		S;
	// This array holds the number of days that it takes planets 1 - 8 to orbit the sun
	public ushort[] 				daysToOrbit = new ushort[] { 88, 225, 365, 687, 4333, 10756, 30687, 60190};
	public Transform				Sun;

	void Awake () {
		if (!S)
			S = this;
		else
			Destroy (this.gameObject);

		DontDestroyOnLoad (S);
	}
}
