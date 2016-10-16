using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SavePlayerProgress : MonoBehaviour {

	List<XMLCharacterInfo> PlayerInfo = new List<XMLCharacterInfo>();
	public LoadPlayerInfo PIScript = new LoadPlayerInfo ();
	public Dropdown DdmathSelected;
	int selectedPlayer = 0;
	float currentAmount;
	int mathSelected = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SavePlayerSession(float xpAmount)
	{
		selectedPlayer = PIScript.playerSelected;

		PlayerInfo = XMLObjectDeserializer.Deserialize<List<XMLCharacterInfo>>(Application.dataPath  + "/XMLPlayerInfo/" + "PlayerCreated.xml");

		currentAmount = (float)PlayerInfo [selectedPlayer].addXp;
		currentAmount += xpAmount;

		XPCalculator ();

		XMLObjectSerializer.Serialize(PlayerInfo, Application.dataPath  + "/XMLPlayerInfo/" + "PlayerCreated.xml");
	}

	public void XPCalculator()
	{
		mathSelected = DdmathSelected.value;

		switch(mathSelected)
		{
		case 0:
			PlayerInfo [selectedPlayer].addXp = (int)currentAmount;
			break;
		case 1:
			PlayerInfo [selectedPlayer].subXp = (int)currentAmount;
			break;
		case 2:
			PlayerInfo [selectedPlayer].multXp = (int)currentAmount;
			break;
		case 3:
			PlayerInfo [selectedPlayer].divXp = (int)currentAmount;
			break;
		default:
			break;
		}
	}
}
