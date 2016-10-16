using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleChoice : MonoBehaviour {

	public Toggle tgGirl;
	public Toggle tgBoy;

	public void ChooseToggleGirl()
	{
		if (tgGirl.isOn == true && tgBoy.isOn == true) 
		{
			tgGirl.isOn = true;
			tgBoy.isOn = false;
		} 
	}

	public void ChooseToggleBoy()
	{
		if (tgBoy.isOn == true && tgGirl.isOn == true) 
		{
			tgGirl.isOn = false;
			tgBoy.isOn = true;
		} 
	}
}
