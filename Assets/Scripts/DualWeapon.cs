using UnityEngine;
using System.Collections;

public class DualWeapon : MonoBehaviour {


	public GameObject weapon;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			PlayerControl control = other.GetComponent<PlayerControl>();
			control.shot = weapon;
			Destroy (gameObject);
		}
	}
}