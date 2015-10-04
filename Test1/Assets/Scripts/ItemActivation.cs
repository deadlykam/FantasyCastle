using UnityEngine;
using System.Collections;

public class ItemActivation : MonoBehaviour {

	public GameObject target;

	EnemyInfo ea;

	// Use this for initialization
	void Start () {
		ea = gameObject.GetComponent<EnemyInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ea.isDead) {
			target.SetActive(true);
			GetComponent<ItemActivation>().enabled = false;
		}
	}
}
