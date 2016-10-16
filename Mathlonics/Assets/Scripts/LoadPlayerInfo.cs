using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadPlayerInfo : MonoBehaviour {

	List<XMLCharacterInfo> PlayerInfo = new List<XMLCharacterInfo>();
	public List<Sprite> PlayerImages;
	public int playerSelected = 0;

	public Text pName;
	public Image pImage;
	public Text pLevel;
	public Text pAddXp;
	public Text pSubXp;
	public Text pMultXp;
	public Text pDivXp;
	public GameObject PlayerInfoPanel;

	// Use this for initialization
	void Start () {
	
		PlayerInfo = XMLObjectDeserializer.Deserialize<List<XMLCharacterInfo>>(Application.dataPath  + "/XMLPlayerInfo/" + "PlayerCreated.xml");
		//SetPlayerInfo (playerSelected);
	}
	
	// Update is called once per frame
	void Update () {
		//SetPlayerInfo (playerSelected);
		if (PlayerInfoPanel.activeInHierarchy) 
		{
			SetPlayerInfo (playerSelected);
		}
	}

	public void SetPlayerInfo(int pSelected)
	{
		pName.text = PlayerInfo[pSelected].name;
		pImage.sprite = PlayerImages [PlayerInfo [pSelected].avatarIndex];
		pLevel.text = PlayerInfo [pSelected].levelNum.ToString ();
		pAddXp.text = PlayerInfo [pSelected].addXp.ToString ();
		pSubXp.text = PlayerInfo [pSelected].subXp.ToString ();
		pMultXp.text = PlayerInfo [pSelected].multXp.ToString ();
		pDivXp.text = PlayerInfo [pSelected].divXp.ToString ();
	}
}
