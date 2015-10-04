using UnityEngine;
using System.Collections;

public class HoverEffect : MonoBehaviour {
	public float hoverForce;

	void OnTriggerStay(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
		}
	}
}
