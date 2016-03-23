using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	public TextMesh pointsTextMeshJ1;
	public TextMesh pointsTextMeshJ2;
	public TextMesh timeRemainingTextMesh;
	private float matchDuration = 45f;
	private float currentTime;
	private bool end = false;

	public GUIStyle style;

	private int scoreJ1 = 0;
	private int scoreJ2 = 0;
	private int scoreToWin = 12;

	private GameObject player1;
	private GameObject player2;
	private GameObject frisbee;
	private GameObject music;

	private Vector3 frisbeePos;
	private Vector3 frisbee_J1 = new Vector3(47,7.5f,0);
	private Vector3 frisbee_J2 = new Vector3(-47,7.5f,0);
	private Vector3 player1_pos;
	private Vector3 player2_pos;

	private string nameOfWinner;
	private int scoreOfWinner;

	// Use this for initialization
	void Start () {
		if ((Random.Range(0, 100)) % 2 == 0) {
			frisbeePos = frisbee_J1;
		} 
		else {
			frisbeePos = frisbee_J2;
		}

		SetTime( matchDuration );
		player1 = (GameObject)Instantiate(Resources.Load("Player 1"));
		player2 = (GameObject)Instantiate(Resources.Load("Player 2"));  
		frisbee = (GameObject)Instantiate(Resources.Load("Frisbee"), frisbeePos, transform.rotation);
		player1_pos = player1.transform.position;
		player2_pos = player2.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		frisbee.GetComponent<Rigidbody> ().transform.Rotate (0, 5, 0,Space.Self);
		currentTime = Mathf.RoundToInt((matchDuration-Time.timeSinceLevelLoad)%60);
		if (currentTime >= 0) {
			SetTime(currentTime);
		}
		OnGUI ();
	}

	void OnGUI(){
		Rect rect = new Rect ((Screen.width/2)-100,(Screen.height/2)-100, Screen.width, Screen.height);
		if (scoreJ1 >= scoreToWin) {
			nameOfWinner = "Player one win";
			scoreOfWinner = scoreJ1;
			end = true;
		}
		if (scoreJ2 >= scoreToWin) {
			nameOfWinner = "Player two win";
			scoreOfWinner = scoreJ2;
			end = true;
		}
		if (currentTime <= 0.0f) {
			if(scoreJ1 > scoreJ2){
				nameOfWinner = "Player one win";
				scoreOfWinner = scoreJ1;
			}
			if(scoreJ1 < scoreJ2){
				nameOfWinner = "Player two win";
				scoreOfWinner = scoreJ2;
			}
			if(scoreJ1 == scoreJ2){
				nameOfWinner = "DRAW";
			}
			end = true;
		}
		if (end) {
			GUILayout.BeginArea(rect);
			GUILayout.BeginHorizontal();
			GUILayout.Label("Winner\n\n"+nameOfWinner+"\n"+scoreOfWinner+"\n\n\nPress Start to continue", style);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();

			if (Input.GetKey (KeyCode.Joystick1Button7) || Input.GetKey (KeyCode.Joystick2Button7)){
				Application.LoadLevel("MainMenu");
			}
		}
	}


	public void SetTime (float time){
		timeRemainingTextMesh.text = time.ToString();
	}

	public void SetPoints(int points, string player){
		frisbee.GetComponent<Frisbee> ().Collision = true;
		if(player == "Player 1(Clone)"){
			scoreJ1+=points;
			pointsTextMeshJ1.text = scoreJ1.ToString();
		}
		if(player == "Player 2(Clone)"){
			scoreJ2 += points;
			pointsTextMeshJ2.text = scoreJ2.ToString();
		}
		Replace (player);
	}

	public void Replace(string player){
		if (player == "Player 1(Clone)") {
			frisbee.transform.position = frisbee_J2;
		}
		if (player == "Player 2(Clone)") {
			frisbee.transform.position = frisbee_J1;
		}
		player1.transform.position = player1_pos;
		player2.transform.position = player2_pos;
		frisbee.GetComponent<Frisbee> ().Collision = false;
	}

	public bool End {
		get {
			return end;
		}
	}

	public GameObject Player1 {
		get {
			return player1;
		}
	}

	public GameObject Player2 {
		get {
			return player2;
		}
	}
}
