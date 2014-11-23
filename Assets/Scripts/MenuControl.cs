using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour 
{
	public static MenuControl instance;

	public GameObject ResetButton;
	public GameObject NextLevelButton;

	void Awake()
	{
		instance = this;
	}

	public void NextLevel()
	{
		NextLevelButton.SetActive (true);
	}

	public void ResetLevel()
	{
		ResetButton.SetActive (true);
	}

}
