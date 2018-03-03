using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public int hp = 150;

	public bool TakeHit (int damage) {
		hp -= damage;
		Debug.Log (gameObject.name + " hit for " + damage + "; hp=" + hp);

		if (hp <= 0) {
			Debug.Log (gameObject.name + " destroyed!");
			gameObject.SetActive (false);
			return false;
		} else {
			return true;
		}
	}
}
