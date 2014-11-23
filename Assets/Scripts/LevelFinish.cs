﻿using UnityEngine;
using System.Collections;

public class LevelFinish: MonoBehaviour
{
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
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			gameController.LevelSuccess();
			rigidbody.velocity = transform.forward * 2.5F;
		}
	}
}