using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building2 : MonoBehaviour {
	public float health = 150;
	
	public bool TakeDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			gameObject.SetActive (false);
			return false; //not standing
		}
		return true; //still standing
	}
}
