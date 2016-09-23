
using UnityEngine;
using System.Collections;

public class BuildingGenerator : MonoBehaviour {
	private Transform myTransform;
	private float diameter;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		diameter = myTransform.localScale.x;

		for (int i = 0; i < 100; i++) {
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = new Vector3 (Random.Range(-50, 50), 0.5F, Random.Range(-50, 50));
			cube.transform.localScale = new Vector3 (1, 20, 1);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}