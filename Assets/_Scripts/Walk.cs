using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
	public float xspeed = 2.0f;
	public float zspeed = 2.0f;
	public int damage = 1;

	private bool attacking = false;
	private GameObject target;

	void Start () {
		GetComponent<Animator> ().SetBool ("walk", true);
	}

	// Update is called once per frame
	void Update () {
		if (!attacking) {
			transform.Translate (xspeed * Time.deltaTime, 0, zspeed * Time.deltaTime);
		} else {
			bool stillStanding = target.GetComponent<Building> ().TakeHit (damage);

			if (!stillStanding) {
				attacking = false;
				GetComponent<Animator> ().SetBool ("walk", true);
			}
		}
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Building") {
			Debug.Log ("Bumped into building");

			GetComponent<Animator> ().SetBool ("attack01", true);
			GetComponent<Animator> ().SetBool ("walk", false);

			attacking = true;
			target = coll.gameObject;
		}
	}
}

