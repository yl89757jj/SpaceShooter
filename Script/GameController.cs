using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public GameObject enemy;
	public Vector3 spawnValues;
	public GUIText gameText;
	public GUIText scoreText;
	public static int score;
	public static bool start;


	void Start ()
	{
		start = true;
		StartCoroutine (SpawnWaves ());
		StartCoroutine (Enemy ());
		score = 0;
		gameText.text = "";


	}

	IEnumerator SpawnWaves ()
	{
		if (start) {
			yield return new WaitForSeconds (2f);
			while (start) {
				for (int times = 0; times < 11; times++) {
					GameObject hazard= hazards[Random.Range(0,hazards.Length)];
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0f, spawnValues.z);
					Instantiate (hazard, spawnPosition, Quaternion.identity);
					yield return new WaitForSeconds (0.8f);
					if (!start) {
						break;
					}
				}
				yield return new WaitForSeconds (2f);

			}
		}
	}

	IEnumerator Enemy(){
		yield return new WaitForSeconds (10f);
		while (GameController.start) {
			Vector3 enemyPosition = new Vector3 (0f, 0f, 10f);
			Instantiate (enemy, enemyPosition, Quaternion.identity);
			yield return new WaitForSeconds (5f);
			if (!start) {
				break;
			}
		}

	}
		
	 void Restart(){
		if (Input.GetKey ("r")) {
			Application.LoadLevel (Application.loadedLevel);//reloaded the current scene

		}
	}

	void Update () {
		scoreText.text = "Score:"+score;
		if (!start) {
			scoreText.text = "Press R to Restart";
			gameText.text = "YOU GOT "+GameController.score;
			Restart ();
		}
	}
}
