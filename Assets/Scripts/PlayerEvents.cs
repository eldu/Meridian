using UnityEngine;
using System.Collections;

public class PlayerEvents : MonoBehaviour {
	ColumnObjectives[] cols;
	Animator anim;
	bool win;
	Time time;
	bool flatland;

	public Camera cam;
	public Camera flat;
	public GameObject enemy;
	public GameObject land;
	public bool stopGeneration;

	// Use this for initialization
	void Start () {
		flatland = false;
		win = false;
		stopGeneration = false;
	}

	void Awake() {
		cam.GetComponent<Camera> ().enabled = true;
		flat.GetComponent<Camera> ().enabled = false;
		anim = GetComponent<Animator> ();
		cols = FindObjectsOfType(typeof(ColumnObjectives)) as ColumnObjectives[];
	}

	IEnumerator waitForFive() {
		yield return new WaitForSeconds(5);
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


//		if (flatland) {
//			cam.GetComponent<Camera> ().enabled = true;
//			flat.GetComponent<Camera> ().enabled = false;
//			flatland = false;
//		}

		if (Input.GetKeyDown ("t")) {
			flatland = true;
			cam.GetComponent<Camera> ().enabled = false;
			flat.GetComponent<Camera> ().enabled = true;

			//land.SetActive (false);


			land.GetComponent<GenerateInfinite> ().hideTiles ();
			stopGeneration = true;

			Invoke("waitforflat", 2);

		}


//			

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

	void waitforflat() {
		//if (flatland) {
		//land.SetActive (true);

			cam.GetComponent<Camera> ().enabled = true;
			flat.GetComponent<Camera> ().enabled = false;
			flatland = false;
			
			stopGeneration = false;
		land.GetComponent<GenerateInfinite> ().showTiles ();

			Invoke ("jumpALittle", 0.3f);

			//Time.timeScale = 1; 
		//}
	}

	void jumpALittle() {
		transform.position += new Vector3 (0, 10, 0);
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
