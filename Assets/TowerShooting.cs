using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour {
	#region Variables
	//public 

	Transform endGoal;
	GameObject[] enemies;
	public Transform[] enemyLocations;
	Transform nearestEnemey;
	float minDist = 5f;
	public float damage = 5f;
	#endregion

	#region Methods
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		endGoal = GameObject.FindGameObjectWithTag("Goal").transform;
		
		nearestEnemey = GetClosestEnemy(enemies);
		if (nearestEnemey != null) {
			Shoot(nearestEnemey);
		}
		//Debug.Log("Closest Enemy is" + nearestEnemey);
	}

	void Shoot(Transform target) {
		target.GetComponent<EnemyHeatlh>().TakeDamage(damage);
	}
	Transform GetClosestEnemy(GameObject[] enemies)
	{
		Transform tMin = null;
		
		Vector3 endPos = endGoal.transform.position;
		foreach (GameObject g in enemies)
		{
			Vector3 cPos = g.transform.position;
			float dist = Vector3.Distance(cPos, endPos);
			if (dist < minDist)
			{
				tMin = g.transform;
				minDist = dist;
			}
		}
		return tMin;
	}


	#endregion
}
