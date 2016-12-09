using UnityEngine;
using System.Collections;

[System.Serializable]//serializable!!!
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
//set up the boundry class

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject playerExplosion;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	private int count;

	void Start () {
		count = 0;
	}

	void FixedUpdate ()//Rigid Body use FixedUpdate
	{
		if (count == 5) {
			Destroy (gameObject);
			Instantiate (playerExplosion, transform.position, transform.rotation);
		//	GameController.announcement = "YOU GOT "+GameController.score;
			GameController.start = false;
			count = 0;
		}

		if (Input.GetKey("space") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().velocity = movement * speed;//move by velocity of RB
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //constrain the position
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);
	
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);	

		}

	void OnTriggerEnter(Collider other){

		if (other.tag != "Boundary"&&other.tag != "Bolt") {
			if (other.tag == "EnemyBolt") {
				count++;
				Destroy (other.gameObject);
			} else {
				count = 0;
				Destroy (gameObject);
				Instantiate (playerExplosion, transform.position, transform.rotation);
			
				GameController.start = false;
			}
		}
	} 

	}
