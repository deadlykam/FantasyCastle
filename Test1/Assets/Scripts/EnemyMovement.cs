using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform target;

	private Animator anim;
	private Alarm_Enemy ae;
	private Enemy_Attack ea;

	void Start () {
		anim = GetComponent<Animator>();
		ae = transform.FindChild ("Range").gameObject.GetComponent<Alarm_Enemy>();
		ea = transform.FindChild ("Range_Attack").gameObject.GetComponent<Enemy_Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!anim.GetBool ("Hurt")) {
			Alarm_Enemy_State ();
			Enemy_Attack_State ();

			if (anim.GetBool ("Move")) {
				LookAtTarget ();
			}
		}
	}

	void Alarm_Enemy_State(){
		if (ae.see_Player) {
			anim.SetBool ("Move", true);
		} else {
			anim.SetBool ("Move", false);
		}
	}

	void Enemy_Attack_State(){
		if (ea.attack) {
			anim.SetBool ("Attack", true);
		} else {
			anim.SetBool ("Attack", false);
		}
	}

	void LookAtTarget(){
		transform.LookAt (target);
	}

	/*void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			anim.SetBool("Attack", true);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			anim.SetBool("Attack", false);
		}
	}*/
}
