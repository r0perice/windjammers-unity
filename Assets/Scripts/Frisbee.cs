using UnityEngine;
using System.Collections;

public class Frisbee : MonoBehaviour {
	
	private GameObject carrier;
	private GameObject go;
	private GameObject let;
	private bool collision = false;
	private ScoreBoard sb;

	// Use this for initialization
	void Start () {
		go = GameObject.Find ("ScoreBoard");
		let = GameObject.Find ("Let");
		sb = go.GetComponent<ScoreBoard> ();
		Physics.IgnoreCollision (this.gameObject.GetComponent<Collider> (), let.GetComponent<Collider> ());
	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player 1(Clone)" || col.gameObject.name == "Player 2(Clone)") {
			Debug.Log ("Player hit");
			carrier = col.gameObject; // Indique qui est le porteur du frisbee
			//BeingCarried (carrier.name); // Met le frisbee devant pour etre relancer
			this.GetComponent<Rigidbody>().isKinematic = true; // Empeche le frisbee de bouger
			carrier.GetComponent<Rigidbody>().isKinematic = true; // Empeche le joueur de bouger
			carrier.GetComponent<Player>().CanThrow = true; // Autorise le joueur à relancer
		}

		if (!collision) {
			switch (col.gameObject.name) {

			case  "Mur_3_J1":
				{
					sb.SetPoints (3, "Player 2(Clone)");
					break;
				}
			case   "Mur_3_J2":
				{
					sb.SetPoints (3, "Player 1(Clone)");
					break;
				}

			case  "Mur_5_J1":
				{
					sb.SetPoints (5, "Player 2(Clone)");
					break;
				}
			case  "Mur_5_J2":
				{
					sb.SetPoints (5, "Player 1(Clone)");
					break;
				}
			}
		}
	}

	public void BeingCarried(string name){
		if (name == "Player 1(Clone)") {
			this.transform.position = new Vector3 (carrier.transform.position.x - this.GetComponent<Renderer> ().bounds.size.x, this.transform.position.y, carrier.transform.position.z);
		}
		if (name == "Player 2(Clone)") {
			this.transform.position = new Vector3 (carrier.transform.position.x + this.GetComponent<Renderer> ().bounds.size.x, this.transform.position.y, carrier.transform.position.z);
		}
	}

	public bool Collision {
		get {
			return collision;
		}
		set {
			collision = value;
		}
	}
}
