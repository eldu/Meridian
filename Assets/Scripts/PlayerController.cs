using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 60;
	private Vector3 moveDir;

	private bool flat = false;
	public GameObject camR;
	public GameObject camF;

	void Start () {
		camR.GetComponent<Camera> ().enabled = true;
		camF.GetComponent<Camera> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		moveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
	}

	void FixedUpdate() {
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + -transform.TransformDirection (moveDir) * moveSpeed * Time.deltaTime);
	}

	void OnGUI( )
	{
		if (Event.current.Equals (Event.KeyboardEvent (KeyCode.T.ToString ()))) {
			flat = !flat;

			if (flat) {
				camR.GetComponent<Camera> ().enabled = false;
				camF.GetComponent<Camera> ().enabled = true;




			} else { // round
				camR.GetComponent<Camera> ().enabled = true;
				camF.GetComponent<Camera> ().enabled = false;



			}
		}
	}
}
