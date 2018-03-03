using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2 : MonoBehaviour {
	public float xSpeed = 0;
	public float zSpeed = 2;
	public string attackAnimName = "attack01";
	public float attackStrength = 1.2f;

	Transform endGoal;
	GameObject[] buildings;

	private bool attacking;
	private GameObject target;
	Transform targett;

	// Use this for initialization
	void Start () {
		//GetComponent<Animator> ().SetBool ("attack03", true);
		GetComponent<Animator> ().SetBool ("walk", true);
	}

	// Update is called once per frame
	void Update() {
		buildings = GameObject.FindGameObjectsWithTag("Building");
		endGoal = GameObject.FindGameObjectWithTag("Goal").transform;
		if (!attacking) {
			if (buildings.Length == 0 && endGoal != null)
			{
				Vector3.MoveTowards(transform.position, endGoal.position, Mathf.Infinity);
			}
			else {
				MoveToNextTarget();
			}
			//transform.Translate (xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
		} else {
			bool standing = target.GetComponent<Building2> ().TakeDamage (attackStrength);
			if (!standing) {
				attacking = false;
				GetComponent<Animator> ().SetBool (attackAnimName, false);
				GetComponent<Animator> ().SetBool ("walk", true);
			}
		}
	}
	void MoveToNextTarget() {
		for (int i = 0; i < buildings.Length; i++) {
			targett = buildings[i].transform;
		}
		if (transform.position != targett.position)
		{
			Vector3.MoveTowards(transform.position, targett.position, Mathf.Infinity);
		}

	}
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Building" || col.gameObject.tag == "Goal") {
			attacking = true;
			target = col.gameObject;
			GetComponent<Animator> ().SetBool (attackAnimName, true);
			GetComponent<Animator> ().SetBool ("walk", false);
		}
	}
}
