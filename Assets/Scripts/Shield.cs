using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	void OnTriggerEnter (Collider otherCollider)
	{

		Transform colliderRoot = otherCollider.transform.root;


		if (colliderRoot.tag == "Player")
		{
			transform.parent = colliderRoot;
			transform.position = colliderRoot.position;
			transform.rigidbody.isKinematic = true;
			transform.tag = "Shield";
		}

		if(colliderRoot.name.Contains("Bolt") && transform.CompareTag("Shield"))
		{
			Destroy(gameObject);
			Destroy(colliderRoot.gameObject);
		}
	}
	
	bool up = true;
	void LateUpdate () 
	{
	
		Color alpha = renderer.material.color;

		float delta = 0.02F;

		if(up)
		{
			alpha.a +=delta;

			if(alpha.a > 0.5F)
				up = false;
		}
		else
		{
			alpha.a -=delta;
			if(alpha.a < 0.15)
				up = true;
		}

		renderer.material.color = alpha;
	}
}
