using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchingPanels : MonoBehaviour {

	public GameObject PanelGameOver;
	public GameObject PanelWon;
	public GameObject PanelGame;
	public GameObject PanelPlayerCreation;
	public GameObject PanelPlayerProfile;
	public GameObject PanelGameOptions;
	public GameObject PanelMainPlayerSelection;

	public void ShowGame()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(false);
		PanelGame.SetActive(true);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (false);
	}

	public void ShowOver()
	{
		PanelGameOver.SetActive(true);
		PanelWon.SetActive(false);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (false);
	}

	public void ShowWon()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(true);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (false);
	}

	public void ShowCharacterSelection()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(false);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (true);
	}

	public void ShowCharacterCreation()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(false);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (true);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (false);
	}

	public void ShowCharacterProfile()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(false);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (true);
		PanelGameOptions.SetActive (false);
		PanelMainPlayerSelection.SetActive (false);
	}

	public void ShowGameOptions()
	{
		PanelGameOver.SetActive(false);
		PanelWon.SetActive(false);
		PanelGame.SetActive(false);
		PanelPlayerCreation.SetActive (false);
		PanelPlayerProfile.SetActive (false);
		PanelGameOptions.SetActive (true);
		PanelMainPlayerSelection.SetActive (false);
	}
}
