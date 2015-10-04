using UnityEngine;
using System.Collections;

public class PlayerAttack_Melee : MonoBehaviour {

	public float forward_Speed;

	private Animator anim;
	private float attack_Timer;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		left_Click_Attack ();
		right_Click_Attack ();
		timer_Calc ();
	}

	void left_Click_Attack(){
		if(Input.GetMouseButtonDown(0)){
			anim.SetBool("click_Left", true);
			attack_Timer = 0.5f;
			Move_Forward();
		}
	}

	void right_Click_Attack(){

	}

	void Move_Forward(){
		transform.Translate (0, 0, forward_Speed);
	}

	void timer_Calc(){
		if (attack_Timer > 0) {
			attack_Timer -= 1 * Time.deltaTime;
		} else {
			anim.SetBool("click_Left", false);
		}
	}
}
