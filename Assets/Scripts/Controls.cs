using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public GUITexture logo;
	private GameObject music;

	void Start () {
		logo.pixelInset = new Rect(0,0, Screen.width, Screen.height);
		music = (GameObject)Instantiate (Resources.Load ("Music"));
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.Joystick1Button1) || Input.GetKey (KeyCode.Joystick2Button1))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
