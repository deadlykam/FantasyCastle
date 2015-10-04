using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Key : MonoBehaviour {

	public Text message;
	public string name;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "Press 'E' to pick up " + name + ".";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "";
		}
	}

	public void kill(){
		Destroy (gameObject);
	}
}
