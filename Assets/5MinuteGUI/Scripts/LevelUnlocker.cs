using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FMG
	{
	public class LevelUnlocker : MonoBehaviour {
		public Text levelText;

		int nextLevel;

		void Start () 
		{
			nextLevel = Application.loadedLevel + 1;

			if(Application.loadedLevel >= Constants.totalLevelCount )
			{
				levelText.text  = "Mission Complete";
				nextLevel = 0;
			}
			else
			{
				levelText.text  = "Unlock level: " + (nextLevel);
				if(Application.loadedLevel< Constants.getMaxLevel() )
					levelText.text  = "Next level: " + (nextLevel);
			}
		}

		public void unlock()
		{

			if(nextLevel > Constants.getMaxLevel() )
				Constants.setMaxLevel(nextLevel);

			Application.LoadLevel(nextLevel);
		}
		

	}
}