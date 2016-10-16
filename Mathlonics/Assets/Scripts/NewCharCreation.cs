using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewCharCreation : MonoBehaviour {

	List<XMLCharacterInfo> PlayerInfo = new List<XMLCharacterInfo> ();
	public InputField CharName;
	public PlayerCharSelection PCSScript = new PlayerCharSelection ();
	public int SelectedButton;

	// Use this for initialization
	void Start () {
	
	}	

	// Update is called once per frame
	void Update () {
	
	}

	public void SaveNewChar()
	{
		PlayerInfo = XMLObjectDeserializer.Deserialize<List<XMLCharacterInfo>> (Application.dataPath + "/XMLPlayerInfo/" + "PlayerCreated.xml");

		PlayerInfo[SelectedButton].name = CharName.text;
		PlayerInfo [SelectedButton].avatarIndex = PCSScript.imageIndex;

		XMLObjectSerializer.Serialize (PlayerInfo, Application.dataPath + "/XMLPlayerInfo/" + "PlayerCreated.xml");
		//Debug.Log ("File is saved as " + CharName.text);
		Debug.Log (Application.persistentDataPath);
	}

	public void CharXMLGenerator()
	{
		for (int i = 0; i <= 3; i++) 
		{
			PlayerInfo.Add (new XMLCharacterInfo());
			PlayerInfo[i].name = "New Character";
			PlayerInfo[i].avatarIndex = 0;
			PlayerInfo[i].levelNum = 1;
			PlayerInfo[i].levelXp = 0;
			PlayerInfo[i].addXp = 0;
			PlayerInfo[i].subXp = 0;
			PlayerInfo[i].multXp = 0;
			PlayerInfo[i].divXp = 0;
		}

		XMLObjectSerializer.Serialize (PlayerInfo, Application.dataPath + "/XMLPlayerInfo/" + "PlayerCreated.xml");
		Debug.Log ("saved");
	}

	public void ButtonSelect_0()
	{
		SelectedButton = 0;
	}
	public void ButtonSelect_1()
	{
		SelectedButton = 1;
	}
	public void ButtonSelect_2()
	{
		SelectedButton = 2;
	}
	public void ButtonSelect_3()
	{
		SelectedButton = 3;
	}

}
