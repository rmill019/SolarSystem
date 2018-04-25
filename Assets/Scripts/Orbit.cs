using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float 			radius;
	public E_Planets 		e_Planet;
	public float			yOffset;

	private float 			speed;
	private float 			angle;
	[SerializeField]
	private int 			daysToOrbit;

	void Start () {
		daysToOrbit = GameManager.daysToOrbit [(int)e_Planet - 1];
		print (gameObject.name + " e_planet: " + GameManager.daysToOrbit [(int)e_Planet - 1]);
		//print (this.gameObject.name + ": " + daysToOrbit);
		speed = (2 * Mathf.PI) / daysToOrbit;
		angle = Random.Range (0, 360);
		//print (gameObject.name + " angle: " + angle);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Vector3.zero;
		angle += speed * Time.deltaTime;

		pos.x = Mathf.Cos (angle) * radius + GameManager.S.Sun.position.x;
		pos.z = Mathf.Sin (angle) * radius + GameManager.S.Sun.position.z;

		transform.position = pos;
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Debug.LogWarning ("Parenting Player to: " + gameObject.name);
			coll.gameObject.GetComponent<TestPlayer>().playerState = E_PlayerState.AtPlanet;
			coll.gameObject.transform.position = this.gameObject.transform.position + new Vector3 (0, 2, 0);
			coll.gameObject.transform.SetParent (this.gameObject.transform);

			// Rethink this calculation
		}
	}
}
