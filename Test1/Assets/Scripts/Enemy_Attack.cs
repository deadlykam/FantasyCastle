using UnityEngine;
using System.Collections;

public class Enemy_Attack : MonoBehaviour {

	public bool attack = false;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			attack = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			attack = false;
		}
	}
}
