using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

	public Text message;
	public bool isKey;
	public string target_Name;

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	public void Action(){
		if (!isKey) {
			if (anim.GetBool ("Open")) {
				anim.SetBool ("Open", false);
			} else {
				anim.SetBool ("Open", true);
			}
		} else {
			if(GameObject.Find("Player_Parent").GetComponent<PlayerItems>().getItem(target_Name)){
				if (anim.GetBool ("Open")) {
					anim.SetBool ("Open", false);
				} else {
					anim.SetBool ("Open", true);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "Press 'E' to open the door.";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			message.text = "";
		}
	}
}
