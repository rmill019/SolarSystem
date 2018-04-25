using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamManager : MonoBehaviour {

	public GameObject			playerClone;
	public Camera				CameraPlanet;
	[Tooltip("0 is Earth, 1 is Galaxy")]
	public Material[]			skyboxMaterials; // 0 is Galaxy, 1 is Earth
	public Vector3				shipOffset;
	public float				shipTargetYRotation;
	public Transform[]			cameraLocations;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		SwitchCam(0);
	}

	void SwitchCam (int camIndex)
	{
		if (Input.GetKey(KeyCode.S))
		{
			Camera.main.enabled = false;
			CameraPlanet.transform.position = cameraLocations[camIndex].position;
			CameraPlanet.enabled = true;
			RenderSettings.skybox = skyboxMaterials[camIndex];

		}
	}
}
