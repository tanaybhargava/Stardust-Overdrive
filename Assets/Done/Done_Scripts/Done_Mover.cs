using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed = -5;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
