using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	private AudioSource audioSource;
	private float newVelocity;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		transform.GetComponent<Rigidbody> ().velocity = new Vector3(Random.Range (-2f, 2f), 
			0f,
			transform.GetComponent<Rigidbody> ().velocity.z);
		InvokeRepeating ("Fire", delay, fireRate);
		StartCoroutine (Turn());



	}

	IEnumerator Turn(){
		while (GameController.start) {
			yield return new WaitForSeconds (Random.Range (0.5f, 2f));
			if (transform.position.x > 0) {
				newVelocity = -Random.Range (0f, 2f);
			} else {
				newVelocity = Random.Range (0f, 2f);
			}if (!GameController.start) {
				break;
			}
		}

	}

	void Fire ()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}

	void FixedUpdate(){
		transform.GetComponent<Rigidbody> ().velocity = new Vector3(newVelocity, 
			0f,
			transform.GetComponent<Rigidbody> ().velocity.z);

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //constrain the position
				0.0f, 
				GetComponent<Rigidbody>().position.z
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);	

	}

}
