using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeatlh : MonoBehaviour {
	#region Variables
	public float health = 100f;
	#endregion

	#region Methods
	private void Update()
	{
		if (health <= 0) {
			Die();
		}
	}
	public void TakeDamage(float damage) {
		health -= damage;
		Debug.Log(gameObject.name + " took " + damage);
	}
	void Die() {
		Destroy(gameObject);
	}
	
	#endregion
}
