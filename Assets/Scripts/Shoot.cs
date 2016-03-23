using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private GameObject frisbee;
	private float speed = 200.0f;
	private Vector3 throwSpeed_J1 = new Vector3(0, 0, 0);
	private Vector3 throwSpeed_J2 = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		name = this.gameObject.name;
		frisbee = GameObject.Find("Frisbee(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Throw(string direction){
		if (direction == "forward_J1") {
			throwSpeed_J1 = new Vector3 (-10, 0, 0);
		}
		if (direction == "up_J1") {
			throwSpeed_J1 = new Vector3 (-10, 0, -6);
		}
		if (direction == "down_J1") {
			throwSpeed_J1 = new Vector3 (-10, 0, 6);
		}

		if (direction == "forward_J2") {
			throwSpeed_J2 = new Vector3 (10, 0, 0);
		}
		if (direction == "up_J2") {
			throwSpeed_J2 = new Vector3 (10, 0, -6);
		}
		if (direction == "down_J2") {
			throwSpeed_J2 = new Vector3 (10, 0, 6);
		}
		frisbee.GetComponent<Rigidbody> ().isKinematic = false;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		this.GetComponent<Player> ().CanThrow = false;
		SetVelocity ();
	} 


	public void SetVelocity(){
		if (name == "Player 1(Clone)") {
			frisbee.GetComponent<Rigidbody> ().velocity = throwSpeed_J1.normalized * speed;
		}
		if (name == "Player 2(Clone)") {
			frisbee.GetComponent<Rigidbody> ().velocity = throwSpeed_J2.normalized * speed;
		}
	}
}
