using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FMG
{
	public class LevelButton : MonoBehaviour {
		public int levelIndex=0;

		public Button button;

		public void onClick()
		{
			Debug.Log (levelIndex+" num");
			Application.LoadLevel(levelIndex);
		}

		public void Refresh()
		{
			if(levelIndex > Constants.getMaxLevel())
				button.interactable = false;
		}

		public void LateUpdate()
		{
			Refresh ();
		}
	}
}