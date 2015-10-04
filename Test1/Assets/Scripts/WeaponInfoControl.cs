using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponInfoControl : MonoBehaviour {

	public string item_Name;
	public Text message;
	public bool activate_Other_Anim;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "Press 'E' to pick up " + item_Name;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "";
		}
	}

	public void kill(){
		if (activate_Other_Anim) {
			GetComponent<ActivateAnim> ().target_Animator.SetBool ("Action", true);
		}

		message.text = "";
		Destroy (gameObject);
	}
}
