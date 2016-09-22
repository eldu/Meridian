using UnityEngine;
using System.Collections;

public class PlayerEvents : MonoBehaviour {
	ColumnObjectives[] cols;
	Animator anim;
	bool win;

	public Camera cam;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		win = false;
	}

	void Awake() {
		anim = GetComponent<Animator> ();
		cols = FindObjectsOfType(typeof(ColumnObjectives)) as ColumnObjectives[];

		print ("Number of Columns: ");
	}

	// Update is called once per frame
	void Update () {
		int numFound = 0;
		float dist = Vector3.Distance (transform.position, enemy.transform.position);
		if (dist <= 20.0f) {
			cam.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration> ().intensity = (1.0f - dist / 20.0f)/2;
		}

		foreach (ColumnObjectives c in cols) {
			if (!c.active) {
				numFound++; 
				// Game continues
			} 

			if (numFound >= 1) {
				print ("Game Over");

				win = true;
				GameObject.Find ("Canvas").GetComponent<Animator> ().SetTrigger ("Win");
			}
		}


			

//		if (Input.GetKeyDown ("r")) {
//			GameObject.Find ("OnScreen").GetComponent<Animator> ().SetTrigger ("recharge");
//		}

//		if (Input.GetKeyDown("r") && Time.time > nextRush) {
//			rushStart = Time.time;
//			rushing = true;
//			anim.speed = 4.0f;
//			Fi
//		}
//
//		if (rushing && Time.time - rushStart > rushLasts) {
//			nextRush = Time.time + rushWait;
//			rushing = false;
//		}
	}

	void OnCollisionEnter (Collision col)
	{

		if (col.gameObject.name == "ColumnObjective") {
			col.gameObject.GetComponent<MeshRenderer> ().material.color = new Color (0.1f, 0.1f, 0.1f);
			col.gameObject.GetComponent<ColumnObjectives> ().active = false;
		} else if (col.gameObject.name == "Enemy" && !win) {
			GameObject.Find ("Canvas").GetComponent<Animator> ().SetTrigger ("Lose");
		}
	}
}
