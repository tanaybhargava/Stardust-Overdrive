using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FMG
{
	public class MenuPlayerNumber : MonoBehaviour
	{
		public Text textbox;
		int num;

		public void Awake()
		{
			num = Constants.getNumberOfPlayers ();
			setText ();
		}
		
		public void Toggle()
		{
			if (num == 1)
				num = 2;
			else
				num = 1;

			Constants.setNumberOfPlayers (num);
			setText ();
		}

		private void setText()
		{
			if (num == 1)
				textbox.text = "One Player";
			else
				textbox.text = "Two Players";
		}
	}
}
