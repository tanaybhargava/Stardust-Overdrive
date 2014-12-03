using UnityEngine;
using System.Collections;

public class DualWeapon : MonoBehaviour {


	public GameObject weapon;
	
	void OnTriggerEnter (Collider otherCollider)
	{
		Transform root = otherCollider.transform.root;

		if (root.transform.root.tag == "Player")
		{
			PlayerControl control = root.GetComponent<PlayerControl>();
			control.shot = weapon;
			Destroy (gameObject);
		}
	}
}