using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	
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
	}

	void OnTriggerEnter (Collider otherCollider)
	{
		Transform colliderRoot = otherCollider.transform.root;

		if (colliderRoot.tag == "Boundary" || colliderRoot.tag == "Enemy" || colliderRoot.tag == "Boss")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (colliderRoot.tag == "Player")
		{
			Instantiate(playerExplosion, colliderRoot.transform.position, colliderRoot.transform.rotation);
			gameController.LevelFailed();
		}
		
		Destroy (colliderRoot.gameObject);
		Destroy (gameObject);
	}
}