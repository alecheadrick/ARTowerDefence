using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2 : MonoBehaviour {
	public float xSpeed = 0;
	public float zSpeed = 2;
	public string attackAnimName = "attack01";
	public float attackStrength = 1.2f;

	private bool attacking;
	private GameObject target;

	// Use this for initialization
	void Start () {
		//GetComponent<Animator> ().SetBool ("attack03", true);
		GetComponent<Animator> ().SetBool ("walk", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking) {
			transform.Translate (xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
		} else {
			bool standing = target.GetComponent<Building2> ().TakeDamage (attackStrength);
			if (!standing) {
				attacking = false;
				GetComponent<Animator> ().SetBool (attackAnimName, false);
				GetComponent<Animator> ().SetBool ("walk", true);
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Building") {
			attacking = true;
			target = col.gameObject;
			GetComponent<Animator> ().SetBool (attackAnimName, true);
			GetComponent<Animator> ().SetBool ("walk", false);
		}
	}
}
