using UnityEngine;
using System.Collections;

public class Alarm_Enemy : MonoBehaviour {

	public bool see_Player = false;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			see_Player = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			see_Player = false;
		}
	}
}
