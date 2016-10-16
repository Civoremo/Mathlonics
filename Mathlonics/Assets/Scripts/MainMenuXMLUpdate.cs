using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuXMLUpdate : MonoBehaviour {

	List<XMLCharacterInfo> PlayerInfo = new List<XMLCharacterInfo>();
	public Text CharOne;
	public Text CharTwo;
	public Text CharThree;
	public Text CharFour;

	// Use this for initialization
	void Start () {
	
		PlayerInfo = XMLObjectDeserializer.Deserialize<List<XMLCharacterInfo>>(Application.dataPath + "/XMLPlayerInfo/" + "PlayerCreated.xml");
		CharOne.text = PlayerInfo [0].name;
		CharTwo.text = PlayerInfo [1].name;
		CharThree.text = PlayerInfo [2].name;
		CharFour.text = PlayerInfo [3].name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
