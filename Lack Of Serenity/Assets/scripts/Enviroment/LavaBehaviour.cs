using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameControlScript.control.SetLavaCollider (gameObject.GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(GameControlScript.control.GetLavaSpeed());
	}
}
