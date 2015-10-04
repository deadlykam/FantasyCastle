using UnityEngine;
using System.Collections;

public class EnemyInfo : MonoBehaviour {

	public float damage;
	public float hp;
	public bool isDead = false;
	public float deathTimer;

	private Animator anim;
	private EnemyMovement em;
	private Alarm_Enemy ae;
	private Enemy_Attack ea;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		em = GetComponent<EnemyMovement>();
		ae = transform.FindChild("Range").gameObject.GetComponent<Alarm_Enemy>();
		ea = transform.FindChild ("Range_Attack").gameObject.GetComponent<Enemy_Attack>();
	}

	void Update(){
		if (isDead) {
			if(deathTimer < 0){
				Enemy_Respawn er = transform.parent.GetComponent<Enemy_Respawn>();
				//Comment me out!
				//er.Spawn();
				//Destroy(gameObject);
			}else{
				deathTimer -= 1 * Time.deltaTime;
			}
		}
	}

	public void Hurt(float amount){
		hp -= amount;

		if (!isDead) {
			if (hp <= 0) {
				anim.SetTrigger ("Dead");
				isDead = true;
				em.enabled = false;
				ae.enabled = false;
				ea.enabled = false;
				
				isDead = true;
			}else{
				Debug.Log("Hurt Squablin");
				anim.SetBool ("Hurt", true);
			}
		}
	}
}
