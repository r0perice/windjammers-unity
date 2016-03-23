using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string p1PressStart, p2PressStart, controls;
	public GUITexture logo;
	public bool p1Ready, p2Ready, showControls, showMainMenu;
	public GUIStyle style;
	private GameObject music;

	void Start () {
		logo.pixelInset = new Rect(0,0, Screen.width, Screen.height);
		music = (GameObject)Instantiate (Resources.Load ("Music"));
	}
		
	void Update () {
		getInput ();
	}

	public void getInput(){
		if (Input.GetKey (KeyCode.Joystick1Button7))
		{
			p1Ready = true;
			p1PressStart = "Player one \n     Ready";
		}
		
		if (Input.GetKey (KeyCode.Joystick2Button7))
		{
			p2Ready = true;
			p2PressStart = "Player two \n     Ready";
		}
		
		if (Input.GetKey (KeyCode.Joystick1Button6) || Input.GetKey (KeyCode.Joystick2Button6)) {
			Application.LoadLevel("Controls");
		}
		
		if (p1Ready && Input.GetKey (KeyCode.Joystick1Button6)) {
			p1Ready = false;
			p1PressStart = "Player one press start";
		}
		
		if (p2Ready && Input.GetKey (KeyCode.Joystick2Button6)) {
			p2Ready = false;
			p2PressStart = "Player two press start";
		}
		
		if (p1Ready && p2Ready)
		{
			Application.LoadLevel("windjammers");
		}
	}

	public void OnGUI()
	{	
		GUILayout.BeginArea(new Rect((Screen.width/2)-250,Screen.height/1.2f,300,100));
		GUILayout.BeginHorizontal();
		GUILayout.Label(p1PressStart, style);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect((Screen.width/2)+50,Screen.height/1.2f,300,100));
		GUILayout.BeginHorizontal();
		GUILayout.Label(p2PressStart, style);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect((Screen.width/2)-100,Screen.height/1.1f,300,100));
		GUILayout.BeginHorizontal();
		GUILayout.Label(controls, style);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
