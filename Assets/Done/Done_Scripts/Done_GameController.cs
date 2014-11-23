using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	private bool gameOver;
	
	public GameObject[] Players;

	public float LevelTime = 30;

	public GameObject LevelFinishObject;

	public int hazardCount;
	
	void Start ()
	{
		gameOver = false;
		StartCoroutine (SpawnWaves ());

		if(FMG.Constants.getNumberOfPlayers() ==2)
		{
			Players[1].SetActive(true);
		
			Players[0].transform.position += new Vector3(-7,0,0);
			Players[1].transform.position += new Vector3(7,0,0);
		}

	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
				break;

			if(Time.timeSinceLevelLoad > LevelTime)
			{
				Instantiate (LevelFinishObject, new Vector3(0,spawnValues.y,spawnValues.z), Quaternion.identity);
				break;
			}
		}

	}

	public void LevelFailed ()
	{
		if(gameOver)
			return;
		FinishGame ();
		MenuControl.instance.ResetLevel ();
		DestroyPlayers ();
	}

	public void LevelSuccess()
	{
		if(gameOver)
			return;
		DestroyPlayers ();
		FinishGame ();
		Invoke ("showEndMenu", 3F);
	}

	public void showEndMenu()
	{
		MenuControl.instance.NextLevel ();
	}

	public void FinishGame()
	{
		gameOver = true;
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