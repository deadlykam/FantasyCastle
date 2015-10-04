using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElevatorAnimation : MonoBehaviour {

	public Text message;

	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	public void Action(){
		if (anim.GetBool ("Up")) {
			anim.SetBool ("Up", false);
		} else {
			anim.SetBool ("Up", true);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			if (anim.GetBool ("Up")) {
				message.text = "Press 'E' to go down.";
			} else {
				message.text = "Press 'E' to go up.";
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "";
		}
	}
}
