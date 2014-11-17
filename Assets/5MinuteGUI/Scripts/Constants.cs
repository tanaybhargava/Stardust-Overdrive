using UnityEngine;
using System.Collections;

namespace FMG
{
	
	public class Constants  
	{
		public static float getAudioVolume()
		{
			return PlayerPrefs.GetFloat("AudioVolume",1);
		}
		public static void setAudioVolume(float vol)
		{
			 PlayerPrefs.SetFloat("AudioVolume",vol);
		}
		public static int getMaxLevel()
		{
			return PlayerPrefs.GetInt("MAX_LEVEL",1);
		}
		public static void setMaxLevel(int val)
		{
			PlayerPrefs.SetInt("MAX_LEVEL",val);
		}

	}
}