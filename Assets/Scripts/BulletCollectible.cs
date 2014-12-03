using UnityEngine;
using System.Collections;

public class BulletCollectible : MonoBehaviour
{

	public int scoreValue;

	
	void OnTriggerEnter (Collider otherCollider)
	{
		Transform colliderRoot = otherCollider.transform.root;

		if (colliderRoot.tag == "Player")
		{
			colliderRoot.SendMessage("changeBulletCount",scoreValue);
			Destroy (gameObject);
		}
	}
}