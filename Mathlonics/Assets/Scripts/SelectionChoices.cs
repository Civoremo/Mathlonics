using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionChoices : MonoBehaviour {

	public Dropdown arithmetic;
	public Dropdown challenge;
	public Dropdown timeFixed;
	public Dropdown timeCountdown;
	public Slider timeAmount;
	public Slider minNumber1;
	public Slider maxNumber1;
	public Slider minNumber2;
	public Slider maxNumber2;

	public Text txtTimeAmount;
	public Text txtMinNumber1;
	public Text txtMaxNumber1;
	public Text txtMinNumber2;
	public Text txtMaxNumber2;
	public GameObject txtExplFixed;
	public GameObject txtExplCountdown;
	public GameObject txtExplComplete;
	public GameObject dropTimeCount;
	public GameObject dropTimeFixed;

	public RandomNumGenerator randNumGenerate;

	int mathSelect;
	int challengeSelect;
	int timeSelect;

	public void Update()
	{
		SetSelections ();
		//ToggleSelect ();
	}

	public void SetSelections()
	{
		int temp;

		temp = (int)timeAmount.value;
		txtTimeAmount.text = temp.ToString ();

		temp = (int)minNumber1.value;
		txtMinNumber1.text = temp.ToString ();

		temp = (int)maxNumber1.value;
		txtMaxNumber1.text = temp.ToString ();

		temp = (int)minNumber2.value;
		txtMinNumber2.text = temp.ToString ();

		temp = (int)maxNumber2.value;
		txtMaxNumber2.text = temp.ToString ();

		mathSelect = arithmetic.value;
		challengeSelect = challenge.value;

		if (challengeSelect == 0) 
		{
			dropTimeFixed.SetActive (true);
			dropTimeCount.SetActive (false);
			txtExplFixed.SetActive (true);
			txtExplCountdown.SetActive (false);
			txtExplComplete.SetActive (false);
			timeSelect = timeFixed.value;
		}
		if (challengeSelect == 1) 
		{
			dropTimeCount.SetActive (true);
			dropTimeFixed.SetActive (false);
			txtExplFixed.SetActive (false);
			txtExplCountdown.SetActive (true);
			txtExplComplete.SetActive (false);
			timeSelect = timeCountdown.value;
		}
		if (challengeSelect == 2) 
		{
			txtExplFixed.SetActive (false);
			txtExplCountdown.SetActive (false);
			txtExplComplete.SetActive (true);
		}
	}

	public void GameSettings()
	{
		SetSelections ();

		switch (mathSelect) 
		{
		case 0:
			randNumGenerate.txtArithemticSymbol.text = "+";
			break;
		case 1:
			randNumGenerate.txtArithemticSymbol.text = "-";
			break;
		case 2:
			randNumGenerate.txtArithemticSymbol.text = "*";
			break;
		case 3:
			randNumGenerate.txtArithemticSymbol.text = "/";
			break;
		default:
			break;
		}

		//Fixed Time
		if (challengeSelect == 0) 
		{

			randNumGenerate.MathChoice = mathSelect;
			float.TryParse (txtTimeAmount.text, out randNumGenerate.time);
			int.TryParse (txtMinNumber1.text, out randNumGenerate.Num1RangeMin);
			int.TryParse (txtMaxNumber1.text, out randNumGenerate.Num1RangeMax);
			int.TryParse (txtMinNumber2.text, out randNumGenerate.Num2RangeMin);
			int.TryParse (txtMaxNumber2.text, out randNumGenerate.Num2RangeMax);

			switch (timeSelect) 
			{
			case 0:
				randNumGenerate.time = 180f;
				break;
			case 1:
				randNumGenerate.time = 300f;
				break;
			case 2:
				randNumGenerate.time = 600f;
				break;
			default:
				break;
			}

			randNumGenerate.progBarAdd = 0;
			randNumGenerate.progBarSub = 0;
			randNumGenerate.RngGen (mathSelect);
			randNumGenerate.AnswerGen ();
		}
		//Countdown challenge
		if (challengeSelect == 1) 
		{

			randNumGenerate.MathChoice = mathSelect;
			float.TryParse (txtTimeAmount.text, out randNumGenerate.time);
			int.TryParse (txtMinNumber1.text, out randNumGenerate.Num1RangeMin);
			int.TryParse (txtMaxNumber1.text, out randNumGenerate.Num1RangeMax);
			int.TryParse (txtMinNumber2.text, out randNumGenerate.Num2RangeMin);
			int.TryParse (txtMaxNumber2.text, out randNumGenerate.Num2RangeMax);

			switch (timeSelect) 
			{
			case 0:
				randNumGenerate.time = 20f;
				break;
			case 1:
				randNumGenerate.time = 40f;
				break;
			case 2:
				randNumGenerate.time = 60f;
				break;
			default:
				break;
			}

			randNumGenerate.RngGen (mathSelect);
			randNumGenerate.AnswerGen ();
		}
		//freemode questions
		if (challengeSelect == 2) 
		{
			randNumGenerate.MathChoice = mathSelect;
			float.TryParse (txtTimeAmount.text, out randNumGenerate.time);
			int.TryParse (txtMinNumber1.text, out randNumGenerate.Num1RangeMin);
			int.TryParse (txtMaxNumber1.text, out randNumGenerate.Num1RangeMax);
			int.TryParse (txtMinNumber2.text, out randNumGenerate.Num2RangeMin);
			int.TryParse (txtMaxNumber2.text, out randNumGenerate.Num2RangeMax);

			randNumGenerate.RngGen (mathSelect);
			randNumGenerate.AnswerGen ();
		}
	}
}
