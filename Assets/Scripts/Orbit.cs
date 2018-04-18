using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float 			radius;
	public E_Planets 		e_Planet;
	public float			yOffset;

	private float 			speed;
	private float 			angle;
	private float 			daysToOrbit;

	void Start () {
		daysToOrbit = (float)GameManager.daysToOrbit [(int)e_Planet];
		print (gameObject.name + " e_planet: " + GameManager.daysToOrbit [(int)e_Planet]);
		//print (this.gameObject.name + ": " + daysToOrbit);
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

	void OnTriggerEnter (Collider coll)
	{
		float yPosition = 0f;

		if (coll.gameObject.tag == "Player")
		{
			Debug.LogWarning ("Parenting Player to: " + gameObject.name);
			coll.gameObject.transform.position = this.gameObject.transform.position;
			coll.gameObject.transform.SetParent (this.gameObject.transform);

			// Rethink this calculation

			yPosition = GetComponent<SphereCollider>().bounds.extents.y + yOffset;
			Vector3 pos = coll.gameObject.transform.position;
			pos.y = yPosition;
			coll.gameObject.transform.position = pos;	
		}
	}
}
