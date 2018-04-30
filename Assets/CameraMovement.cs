using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject			followTarget;
	public float				moveSpeed;
	private Vector3				offset;

	// Use this for initialization
	void Start () {
		offset = transform.GetChild(0).transform.localPosition;
		print (offset);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (followTarget)
		{
			//transform.GetChild(0).transform.position = offset;
			//transform.position = Vector3.Lerp (transform.position, followTarget.transform.position, Time.deltaTime * moveSpeed);
		}
	}
}
