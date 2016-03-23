using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private Shoot shoot;
	private ScoreBoard sc;
	private GameObject go;
	
	private bool canThrow = false;
	//private bool canDash = true;
	private float speed = 0.6f;
	private float dash = 1.5f;
	private float nextDash = 0.0f;
	private float rateDash = 0.8f;

	// Use this for initialization
	void Start () {
		shoot = this.GetComponent<Shoot>();
		go = GameObject.Find ("ScoreBoard");
		sc = go.GetComponent<ScoreBoard> ();
		name = this.gameObject.name;


	}
	
	// Update is called once per frame
	void Update () {
		if (sc.End == false) {
			Movement ();
		}
	}


	// Input.GetKey (KeyCode.Joystick1Button0 : A
	// Input.GetKey (KeyCode.Joystick1Button1 : B
	// Input.GetKey (KeyCode.Joystick1Button2 : X
	// Input.GetKey (KeyCode.Joystick1Button3 : Y
	// Input.GetKey (KeyCode.Joystick1Button4 : LB
	// Input.GetKey (KeyCode.Joystick1Button5 : RB
	// Input.GetKey (KeyCode.Joystick1Button6 : Back
	// Input.GetKey (KeyCode.Joystick1Button7 : Start
	// Input.GetKey (KeyCode.Joystick1Button8 : Left press
	// Input.GetKey (KeyCode.Joystick1Button9 : Right press

	public void Movement(){
		if (canThrow == false) {
			if (name == "Player 1(Clone)"){
				if (Input.GetKey (KeyCode.Joystick1Button0) && Time.timeSinceLevelLoad > nextDash){
					dash+=speed;
					nextDash = Time.timeSinceLevelLoad + rateDash;
				}
				Vector3 reculer = Vector3.left*Input.GetAxis("J1_Left_Horizontal");
				Vector3 avancer = Vector3.left*Input.GetAxis("J1_Left_Horizontal");
				Vector3 descendre = Vector3.forward*Input.GetAxis("J1_Left_Vertical");
				Vector3 monter = Vector3.forward*Input.GetAxis("J1_Left_Vertical");
				Vector3 move = (reculer+avancer+descendre+monter);

				this.GetComponent<Rigidbody>().MovePosition(this.transform.position+move*dash);
				if(nextDash <= Time.timeSinceLevelLoad+rateDash-0.10f){
					dash = speed;
				}

			}
			if (name == "Player 2(Clone)"){
				if (Input.GetKey (KeyCode.Joystick2Button0) && Time.timeSinceLevelLoad > nextDash){
					dash+=speed;
					nextDash = Time.timeSinceLevelLoad + rateDash;
				}
				Vector3 reculer = Vector3.left*Input.GetAxis("J2_Left_Horizontal");
				Vector3 avancer = Vector3.left*Input.GetAxis("J2_Left_Horizontal");
				Vector3 descendre = Vector3.forward*Input.GetAxis("J2_Left_Vertical");
				Vector3 monter = Vector3.forward*Input.GetAxis("J2_Left_Vertical");
				Vector3 move = (reculer+avancer+descendre+monter);

				this.GetComponent<Rigidbody>().MovePosition(this.transform.position+move*dash);
				if(nextDash <= Time.timeSinceLevelLoad+rateDash-0.10f){
					dash = speed;
				}
			}
		} 
		else {
			if (name == "Player 1(Clone)"){
				if (Input.GetKey (KeyCode.Joystick1Button0)){
					shoot.Throw ("forward_J1");
				}

				if (Input.GetKey (KeyCode.Joystick1Button0) && Input.GetAxis("J1_Left_Vertical") < 0) {
					shoot.Throw ("up_J1");
				}

				if (Input.GetKey (KeyCode.Joystick1Button0) && Input.GetAxis("J1_Left_Vertical") > 0) {
					shoot.Throw ("down_J1");
				}
			}
			if (name == "Player 2(Clone)"){
				if (Input.GetKey (KeyCode.Joystick2Button0)){
					shoot.Throw ("forward_J2");
				}
				
				if (Input.GetKey (KeyCode.Joystick2Button0) && Input.GetAxis("J2_Left_Vertical") < 0f) {
					shoot.Throw ("up_J2");
				}
				
				if (Input.GetKey (KeyCode.Joystick2Button0) && Input.GetAxis("J2_Left_Vertical") > 0) {
					shoot.Throw ("down_J2");
				}
			}
		}
	}

	public void Carry(GameObject carriedObject){
		
	}

	public bool CanThrow {
		get {
			return canThrow;
		}
		set {
			canThrow = value;
		}
	}
}
