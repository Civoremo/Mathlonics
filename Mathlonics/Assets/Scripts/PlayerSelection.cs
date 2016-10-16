using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour {

	public Button btnPlayer;
	public SwitchingPanels PanelChangeScript;
	string buttontext;
	public LoadPlayerInfo PIScript = new LoadPlayerInfo();


	public void SelectPlayer()
	{
		Text tempBtnTxt = btnPlayer.GetComponentInChildren (typeof(Text)) as Text;
		buttontext = tempBtnTxt.text;

		if (buttontext != "New Character") 
		{
			PanelChangeScript.ShowCharacterProfile ();
		} 
		else 
		{
			
			PanelChangeScript.ShowCharacterCreation ();
		}
	}

	public void ButtonSelected_0()
	{
		PIScript.playerSelected = 0;
	}
	public void ButtonSelected_1()
	{
		PIScript.playerSelected = 1;
	}
	public void ButtonSelected_2()
	{
		PIScript.playerSelected = 2;
	}
	public void ButtonSelected_3()
	{
		PIScript.playerSelected = 3;
	}
}
