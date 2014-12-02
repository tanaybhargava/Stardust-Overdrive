using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public static Done_GameController instance;


	// Public Members

	public float LevelTime = 30;
	public GameObject LevelFinishObject;

	//Boundaries
	public Vector3 spawnValues;
	
	//Spawn Objects
	public GameObject[] Players;

	public float startWait;

	public float hazardSpawnWait;
	public GameObject[] hazards;

	public float collectibleSpawnWait;
	public GameObject[] collectibles;

	public float enemySpawnWait;
	public GameObject[] enemies;
	

	//Private members
	private bool spawnEnable = true;
	private bool gameOver;

	void Awake()
	{
		instance = this;
	}

	void Start ()
	{
		gameOver = false;

		if(FMG.Constants.getNumberOfPlayers() ==2)
		{
			Players[1].SetActive(true);
		
			Players[0].transform.position += new Vector3(-7,0,0);
			Players[1].transform.position += new Vector3(7,0,0);

			hazardSpawnWait /= 0.75F;
			enemySpawnWait /= 0.75F;
		}

		StartCoroutine (LevelTimer());
		StartCoroutine (SpawnObjects (hazards,startWait,hazardSpawnWait));
		StartCoroutine (SpawnObjects (collectibles,startWait*1.5F,collectibleSpawnWait));
		StartCoroutine (SpawnObjects (enemies,startWait*2,enemySpawnWait));
	}

	IEnumerator LevelTimer()
	{
		yield return new WaitForSeconds (LevelTime);
		if(!gameOver)
		{
			spawnEnable = false;
			yield return new WaitForSeconds (1.5F);
			spawnFinish ();
		}
	}

	IEnumerator SpawnObjects (GameObject[] objectArray,float startWaitTime, float spawnWaitTime)
	{
		yield return new WaitForSeconds (startWaitTime);
		while (spawnEnable && objectArray!=null && objectArray.Length > 0)
		{
			GameObject obj = objectArray [Random.Range (0, objectArray.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (obj, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWaitTime);
		}
	}

	public void spawnFinish ()
	{
		Instantiate (LevelFinishObject, new Vector3(0,spawnValues.y,spawnValues.z), Quaternion.identity);
	}

	public void LevelFailed ()
	{
		if(gameOver)
			return;
		FinishGame ();
		MenuControl.instance.ResetLevel ();
	}

	public void LevelSuccess()
	{
		if(gameOver)
			return;
		DestroyPlayers ();
		Invoke ("showEndMenu", 3F);
	}

	public void showEndMenu()
	{
		MenuControl.instance.NextLevel ();
	}

	public void FinishGame()
	{
		gameOver = true;
		spawnEnable = false;
		DestroyPlayers ();
	}

	public void DestroyPlayers()
	{
		foreach(GameObject obj in Players)
		{
			if(obj!= null)
				obj.SetActive(false);
		}
	}

}