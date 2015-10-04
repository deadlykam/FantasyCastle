using UnityEngine;
using System.Collections;

public class ActivateAnim : MonoBehaviour {

	public Animator target_Animator;
	public bool check_Self;

	private bool stop_Check_Self = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (check_Self) {
			if(!stop_Check_Self){
				if(GetComponent<Animator>().GetBool("Done")){
					target_Animator.SetBool("Action", true);
					stop_Check_Self = true;
				}
			}
		}
	}
}
