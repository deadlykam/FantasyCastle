using UnityEngine;
using System.Collections;

public class PlayerItems : MonoBehaviour {

	public bool key_Door_K = false;

	public void item_picked_up(string name){
		if (name.Equals ("Door_K")) {
			key_Door_K = true;
		}
	}

	public bool getItem(string name){
		if (name.Equals ("Door_K")) {
			return key_Door_K;
		}

		return false;
	}
}
