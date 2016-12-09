using UnityEngine;
using System.Collections;

public class DestroyedByBolt : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int score;


	void OnTriggerEnter(Collider other){
		
		if (other.tag != "Boundary"&&other.tag != "Enemy"&&other.tag != "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			GameController.score+=score;
		} 

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

}
