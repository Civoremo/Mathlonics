using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Character Profile")]
public class XMLCharacterInfo {

	public string name;
	public int avatarIndex;
	public int levelNum;
	public int levelXp;
	public float addXp;
	public float subXp;
	public float multXp;
	public float divXp;

}