using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
	
	}
		
	void Awake() {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (false) {
			anim.SetTrigger ("GameOver");
		}
	
	}
}
