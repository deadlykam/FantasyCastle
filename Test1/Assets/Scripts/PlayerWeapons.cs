using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour {

	private GameObject Hand_R;
	private GameObject Body;

	void Start(){
		Hand_R = transform.FindChild ("Player").gameObject.transform.FindChild ("Armature").gameObject.transform.FindChild ("Body").gameObject.transform.FindChild ("Arm_R").gameObject.transform.FindChild ("Hand_R").gameObject;
		Body = transform.FindChild ("Player").gameObject.transform.FindChild ("Armature").gameObject.transform.FindChild ("Body").transform.gameObject;
	}

	public void ActivateWeapon_Melee(string weapon){
		Hand_R.transform.FindChild (weapon).gameObject.SetActive (true);
	}

	public void ActivateWeapon_Range(string weapon){
		Body.transform.FindChild (weapon).gameObject.SetActive (true);
	}
}
