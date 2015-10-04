using UnityEngine;
using System.Collections;

public class RotationControl : MonoBehaviour {

	public Vector3 rotate;
	public float speed;

	// Update is called once per frame
	void Update () {

		transform.Rotate (rotate * speed * Time.deltaTime);
	}
}
