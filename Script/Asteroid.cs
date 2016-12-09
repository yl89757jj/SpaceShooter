using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere*5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
