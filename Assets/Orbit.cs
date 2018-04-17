using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float 			radius;
	public E_Planets 		e_Planet;

	private float 			speed;
	private float 			angle;
	private float 			daysToOrbit;

	void Start () {
		daysToOrbit = GameManager.S.daysToOrbit [(int)e_Planet];
		print (this.gameObject.name + ": " + daysToOrbit);
		speed = (2 * Mathf.PI) / daysToOrbit;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Vector3.zero;
		angle += speed * Time.deltaTime;

		pos.x = Mathf.Cos (angle) * radius + GameManager.S.Sun.position.x;
		pos.z = Mathf.Sin (angle) * radius + GameManager.S.Sun.position.z;

		transform.position = pos;

	}
}
