using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			transform.parent = other.transform;
			transform.position = other.transform.position;
			transform.rigidbody.isKinematic = true;
			transform.tag = "Shield";
		}

		if(other.name.Contains("Bolt") && transform.CompareTag("Shield"))
			Destroy(other.gameObject);
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
			if(alpha.a < 0)
				up = true;
		}

		renderer.material.color = alpha;
	}
}
