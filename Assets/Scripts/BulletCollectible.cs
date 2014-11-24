using UnityEngine;
using System.Collections;

public class BulletCollectible : MonoBehaviour
{

	public int scoreValue;

	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			other.SendMessage("changeBulletCount",scoreValue);
			Destroy (gameObject);
		}
	}
}