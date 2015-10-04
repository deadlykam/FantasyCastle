using UnityEngine;
using System.Collections;

public class WeaponAttack_Melee : MonoBehaviour {

	public float damage;

	private Animator anim;

	void Start(){
		anim = transform.parent.parent.parent.parent.parent.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		if (anim.GetBool ("Attacking")) {
			if (other.CompareTag ("Enemy")) {
				EnemyInfo ei = other.gameObject.GetComponentInParent<EnemyInfo> ();
				if (ei != null) {
					ei.Hurt (damage);
					//Debug.Log ("Damaging Enemy!");
				}
			}
		}
	}
}
