using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {

	// Use this for initialization
	public GameObject playerExplosion;
	public GameObject explosion;
	public int score;
	private int count;


	void OnTriggerEnter(Collider other){

		if (other.tag != "Boundary"&& other.tag != "Asteroid"&& other.tag != "EnemyBolt") {
			if (other.tag == "Bolt") {
				count++;
				Destroy (other.gameObject);
			}
		}
	} 
		

	// Use this for initialization
	void Start () {
		count = 0;
	}



	void Update(){
		if (count == 3) {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			GameController.score+=score;
			count = 0;

		}
	}
}
