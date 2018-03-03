using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	public float spinSpeed = 30;
	public ParticleSystem effect;
	public GameObject icon;

	private bool found = false;


	void Update () {
		if (!found) {
			return;
		}

		transform.Rotate (0, spinSpeed * Time.deltaTime, 0);
	}

	void Found () {
		//Debug.Log (transform.parent.name + "Found");
		icon.SetActive (true);
		effect.Play ();
		found = true;
	}

	void Lost () {
		found = false;
	}

	public void Clicky() {
		Debug.Log ("click!!!!");
		Application.OpenURL ("http://www.grandcircus.co");
	}
}
