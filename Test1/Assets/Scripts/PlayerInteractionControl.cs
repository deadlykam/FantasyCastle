using UnityEngine;
using System.Collections;

public class PlayerInteractionControl : MonoBehaviour {

	private bool isAction = false;
	private float action_Counter = .5f;
	private PlayerWeapons pw;

	// Use this for initialization
	void Start () {
		pw = GetComponent<PlayerWeapons>();
	}
	
	// Update is called once per frame
	void Update () {
		MakeAction ();
	}

	void MakeAction(){
		if (Input.GetButtonDown ("Action")) {
			isAction = true;
			action_Counter = .5f;
			//Debug.Log("Action Pressed!");
		}

		if (action_Counter <= 0) {
			isAction = false;
		} else {
			action_Counter -= 1 * Time.deltaTime;
		}
	}

	void OnTriggerStay(Collider other){
		if (isAction) {
			//Debug.Log("Inside Fire1 Condition");
			Debug.Log("isAction Pressed PlayerInteraction");
			if (other.gameObject.CompareTag ("Door")) {
				Debug.Log("in Door");
				DoorAnimation da = other.gameObject.GetComponent<DoorAnimation>();
				if(da != null){
					Debug.Log("door open/close");
					da.Action();
				}else{
					Debug.Log("DoorAnimation for 'Interactive' object not found!");
				}
			}else if (other.gameObject.CompareTag ("Elevator")) {
				ElevatorAnimation ea = other.gameObject.GetComponent<ElevatorAnimation>();
				if(ea != null){
					ea.Action();
				}
			}else if(other.gameObject.CompareTag("Weapon_Melee")){
				WeaponInfoControl wic = other.gameObject.GetComponent<WeaponInfoControl>();
				if(wic != null){
					pw.ActivateWeapon_Melee(wic.item_Name);
					wic.kill();
				}
			}else if(other.gameObject.CompareTag("Key")){
				Key key = other.gameObject.GetComponent<Key>();
				if(key != null){
					GetComponent<PlayerItems>().item_picked_up(key.name);
					key.kill();
				}
			}else{
				Debug.Log("No tag found. Current tag is " + other.gameObject.tag);
			}
			isAction = false;
		}
	}

}
