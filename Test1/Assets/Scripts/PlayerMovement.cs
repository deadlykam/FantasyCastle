using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public float turnSpeed = 1f;
	public float ver_Min = 0;
	public float ver_Max = 0;

	private bool isAction = false;
	private Animator anim;
	private GameObject pivot_Camera;
	private PlayerWeapons pw;
	private float action_Counter = .5f;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
		pw = GetComponent<PlayerWeapons>();
		pivot_Camera = transform.Find ("pivot").gameObject.transform.Find("pivot_Camera").gameObject;
		//pivot_Camera = transform.Find ("pivot_Camera").gameObject;
	}

	void Update () {
		Move ();
		Turn ();
		MakeAction ();
	}

	void Move(){
		if (!anim.GetBool ("click_Left")) {
			float forward = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			float sideward = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			//Debug.Log ("forward: " + forward);
			transform.Translate (sideward, 0, forward);

			if (forward > 0) {
				anim.SetBool ("move", true);
				//Debug.Log("Run Animation");
			} else {
				anim.SetBool ("move", false);
				//Debug.Log("Idle Animation");
			}
		}
	}

	void Turn(){
		float horizantal = Input.GetAxis("Mouse X") * turnSpeed;
		float vertical = Input.GetAxis ("Mouse Y") * -turnSpeed;

		transform.Rotate (0, horizantal, 0);

		Vector3 v_Rot = pivot_Camera.transform.localEulerAngles;
		v_Rot.x = Mathf.Clamp (v_Rot.x + vertical, ver_Min, ver_Max);
		pivot_Camera.transform.localEulerAngles = v_Rot;
	}

	void MakeAction(){
		if (Input.GetButtonDown ("Action")) {
			isAction = true;
			action_Counter = .5f;
		}

		action_Counter -= 1 * Time.deltaTime;

		if (action_Counter <= 0) {
			isAction = false;
		}

		/*if (Input.GetButton ("Action")) {
			isAction = true;
			//Debug.Log("Take Action");
		}*/
	}


	void OnTriggerStay(Collider other){
		if (isAction) {
			//Debug.Log("Inside Fire1 Condition");
			//Debug.Log("isAction Pressed");
			if (other.gameObject.CompareTag ("Door")) {
			//	Debug.Log("in Door");
				DoorAnimation da = other.gameObject.GetComponent<DoorAnimation>();
				if(da != null){
			//		Debug.Log("door open/close");
					da.Action();
				}else{
			//		Debug.Log("DoorAnimation for 'Interactive' object not found!");
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
			}else if(other.gameObject.CompareTag("Weapon_Range")){
				WeaponInfoControl wic = other.gameObject.GetComponent<WeaponInfoControl>();
				if(wic != null){
					pw.ActivateWeapon_Range(wic.item_Name);
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
