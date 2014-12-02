using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public GameObject playerExplosion;

	public GameObject selfExplosion;

	private Done_GameController gameController;

	public TextMesh healthText;

	private int health = 100;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		healthText.text = health.ToString();
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}


		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.LevelFailed();
		}

		if(other.CompareTag("PlayerBolt"))
		{
			health -= 3;
			healthText.text = health.ToString();

			if(health <=0)
			{
				gameController.spawnFinish();
				Instantiate(selfExplosion, transform.position+ new Vector3(0,-10,0), transform.rotation);
				Destroy(transform.root.gameObject);
				Invoke("EndGame",2F);
			}
		}

		Destroy (other.gameObject);
	}

	void EndGame()
	{
		gameController.spawnFinish ();
	}
}
