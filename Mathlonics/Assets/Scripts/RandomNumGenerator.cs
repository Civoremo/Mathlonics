using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomNumGenerator : MonoBehaviour {

	public ScoreCalculator scoreCalcScript;
	public SelectionChoices selectGameChoices;
	public SwitchingPanels switchPanelsScript;

	public Text txtNum1;
	public Text txtNum2;
	public Text txtAnswer;
	public Text txtArithemticSymbol;

	public int Num1RangeMin = 0;
	public int Num1RangeMax = 15;
	public int Num2RangeMin = 0;
	public int Num2RangeMax = 10;
	public int MathChoice = 0;

	private int num1;
	private int num2;

	public GameObject PanelGameOver;
	public GameObject PanelWon;
	public GameObject PanelGame;
	public GameObject PanelSelection;
	public GameObject PanelPlayerProfile;
	public GameObject PanelPlayerCreation;
	public GameObject PanelMainPlayerSelection;

	void Start()
	{
		//ShowGame ();
		//ShowSelection();
		//RngGen (MathChoice);
		//AnswerGen ();
		ShowMainPlayerSelection();
	}

	public void ShowGame()
	{
		//PanelSelection.SetActive (false);
		//PanelGameOver.SetActive(false);
		//PanelWon.SetActive(false);
		//PanelGame.SetActive(true);
		switchPanelsScript.ShowGame();
		timeOn = true;
	}

	public void ShowOver()
	{
		scoreCalcScript.OverFinal ();

		//PanelSelection.SetActive (false);
		//PanelGameOver.SetActive(true);
		//PanelWon.SetActive(false);
		//PanelGame.SetActive(false);
		switchPanelsScript.ShowOver();
		timeOn = false;
	}

	public void ShowWon()
	{
		scoreCalcScript.WonFinal ();

		//PanelSelection.SetActive (false);
		//PanelGameOver.SetActive(false);
		//PanelWon.SetActive(true);
		//PanelGame.SetActive(false);
		switchPanelsScript.ShowWon();
		timeOn = false;
	}

	public void ShowSelection()
	{
		//PanelSelection.SetActive (true);
		//PanelGameOver.SetActive(false);
		//PanelWon.SetActive(false);
		//PanelGame.SetActive(false);
		switchPanelsScript.ShowGameOptions();
		timeOn = false;
	}

	public void ShowPlayerProfile()
	{
		switchPanelsScript.ShowCharacterProfile ();
		timeOn = false;
	}

	public void ShowMainPlayerSelection()
	{
		switchPanelsScript.ShowCharacterSelection ();
		timeOn = false;
	}

	public void ShowPlayerCreation()
	{
		switchPanelsScript.ShowCharacterCreation ();
		timeOn = false;
	}

	//////////
	/// timer
	/// //////
	/// 
	public Text timeRemaining;
	public float time = 80;
	public float addTime = 5;
	public float subTime = 2;
	float minutes = 0;
	float seconds = 0;
	bool timeOn = true;

	// Update is called once per frame
	void Update () {

		if(timeOn && time > 0)
		{
			time -= Time.deltaTime;

			minutes = Mathf.Floor( time / 60);
			seconds = time % 60;

			timeRemaining.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
		if (time <= 0) 
		{
			ShowOver ();
		}
		if (progBar.fillAmount == 1) 
		{
			ShowWon ();
		}
	}

	//generate a random math problem
	public void RngGen(int num)
	{
		//Addition
		if (num == 0) 
		{
			num1 = Random.Range (Num1RangeMin, Num1RangeMax);
			num2 = Random.Range (Num2RangeMin, Num2RangeMax);

			txtNum1.text = "" + num1.ToString ();
			txtNum2.text = "" + num2.ToString ();

			txtAnswer.text = "" + (num1 + num2);
		}

		//Subtraction
		if (num == 1) 
		{
			int temp;

			num1 = Random.Range (Num1RangeMin, Num1RangeMax);
			num2 = Random.Range (Num2RangeMin, Num2RangeMax);

			if (num1 >= num2) 
			{
				txtNum1.text = "" + num1.ToString ();
				txtNum2.text = "" + num2.ToString ();

				txtAnswer.text = "" + (num1 - num2);
			} 
			else if (num1 < num2) 
			{
				temp = num1;
				num1 = num2;
				num2 = temp;

				txtNum1.text = "" + num1.ToString ();
				txtNum2.text = "" + num2.ToString ();

				txtAnswer.text = "" + (num1 - num2);
			}
		}

		//Multiplication
		if (num == 2) 
		{
			//int temp;

			num1 = Random.Range (Num1RangeMin, Num1RangeMax);
			num2 = Random.Range (Num2RangeMin, Num2RangeMax);

			txtNum1.text = "" + num1.ToString ();
			txtNum2.text = "" + num2.ToString ();

			txtAnswer.text = "" + (num1 * num2);
		}

		//Division
		//fix the answers -------------
		if (num == 3) 
		{
			int temp;

			num1 = Random.Range (Num1RangeMin, Num1RangeMax);
			num2 = Random.Range (Num2RangeMin, Num2RangeMax);

			temp = Random.Range (0, 1);

			switch (temp) 
			{
			case 0:
				{
					temp = num1 * num2;

					txtNum1.text = "" + temp.ToString ();
					txtNum2.text = "" + num1.ToString ();

					txtAnswer.text = "" + (temp / num1);
				}
				break;
			case 1:
				{
					temp = num1 * num2;

					txtNum1.text = "" + temp.ToString ();
					txtNum2.text = "" + num2.ToString ();

					txtAnswer.text = "" + (temp / num2);
				}
				break;
			default:
				break;
			}
		}
	}

	//////////////////////////////////////
	// generating the text and answers for the clickable buttons
	//////////////////////////////////////
	/// 
	public Text txtBtnNum1;
	public Text txtBtnNum2;
	public Text txtBtnNum3;
	public Text txtBtnNum4;

	int[] temp = new int[3];
	public int wrongRange = 10;

	public void AnswerGen()
	{
		RngGen (MathChoice);
		WrongAnswerGen(txtAnswer.text);
		AnswerRandomizer (txtAnswer.text);
	}
		
	private void AnswerRandomizer(string numStr)
	{
		int randBtn = Random.Range (0, 3);

		switch (randBtn) 
		{
		case 0:
			txtBtnNum1.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 1:
			txtBtnNum2.text = numStr;
			txtBtnNum1.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 2:
			txtBtnNum3.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum1.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 3:
			txtBtnNum4.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum1.text = temp[2].ToString ();
			break;
		default:
			break;
		}

	}

	private void WrongAnswerGen(string s)
	{
		int ansNum;
		int.TryParse (s, out ansNum);

		int rndInt;
		int tempAns;

		//generate variation for answers
		for (int i = 0; i < 3; i++) 
		{
			temp [i] = Random.Range (1, wrongRange);
		}

		//check to make sure the variations are not identical
		for (int n = 0; n < 3; n++) 
		{
			if (temp [0] == temp [1]) {
				temp [1] = Random.Range (1, wrongRange);
			}
			if (temp [0] == temp [2]) {
				temp [2] = Random.Range (1, wrongRange);
			}
			if (temp [1] == temp [2]) {
				temp [2] = Random.Range (1, wrongRange);
			}
		}

		switch (MathChoice) 
		{
		//addition
		case 0:
			{
				for (int x = 0; x < 3; x++) 
				{
					rndInt = Random.Range (0, 4);

					if (rndInt == 0 || rndInt == 3) 
					{
						tempAns = ansNum - temp [x];

						if (tempAns >= 0) 
						{
							temp [x] = tempAns;
						} 
						else 
						{
							temp [x] += ansNum;
						}

					}
					else if (rndInt == 1 || rndInt == 4) 
					{
						temp [x] += ansNum;
					}
				}
			}
			break;

		//subtraction
		case 1:
			{
				for (int x = 0; x < 3; x++) 
				{
					rndInt = Random.Range (0, 1);

					if (rndInt == 0 || rndInt == 3) 
					{
						tempAns = ansNum - temp [x];

						if (tempAns >= 0) 
						{
							temp [x] = tempAns;
						} 
						else 
						{
							temp [x] += ansNum;
						}

					}
					else if (rndInt == 1 || rndInt == 4) 
					{
						temp [x] += ansNum;
					}
				}	
			}
			break;

		//multiplication
		case 2:
			{
				for (int x = 0; x < 3; x++) 
				{
					rndInt = Random.Range (0, 1);

					if (rndInt == 0 || rndInt == 3) 
					{
						tempAns = ansNum - temp [x];

						if (tempAns >= 0) 
						{
							temp [x] = tempAns;
						} 
						else 
						{
							temp [x] += ansNum;
						}

					}
					else if (rndInt == 1 || rndInt == 4) 
					{
						temp [x] += ansNum;
					}
				}
			}
			break;

		//division
		case 3:
			{
				for (int x = 0; x < 3; x++) 
				{
					rndInt = Random.Range (0, 1);

					if (rndInt == 0 || rndInt == 3) 
					{
						tempAns = ansNum - temp [x];

						if (tempAns >= 0) 
						{
							temp [x] = tempAns;
						} 
						else 
						{
							temp [x] += ansNum;
						}

					}
					else if (rndInt == 1 || rndInt == 4) 
					{
						temp [x] += ansNum;
					}
				}
			}
			break;

		default:
			break;
		}
	}


	//////////////////////////////////
	/// keep track of player score
	/// ///////////////////////////////
	///
	public Text txtCorrect;
	public Text txtWrong;

	int goodAns = 0;
	int badAns = 0;

	public void BtnOne()
	{
		if (txtBtnNum1.text == txtAnswer.text) 
		{
			ProgressBar (1);
			time += addTime;
			goodAns++;

		} else 
		{
			ProgressBar (2);
			time -= subTime;
			badAns++;
		}
		txtCorrect.text = goodAns.ToString ();
		txtWrong.text = badAns.ToString ();
		AnswerGen ();
	}

	public void BtnTwo()
	{
		if (txtBtnNum2.text == txtAnswer.text) 
		{
			ProgressBar (1);
			time += addTime;
			goodAns++;

		} else 
		{
			ProgressBar (2);
			time -= subTime;
			badAns++;
		}
		txtCorrect.text = goodAns.ToString ();
		txtWrong.text = badAns.ToString ();
		AnswerGen ();
	}

	public void BtnThree()
	{
		if (txtBtnNum3.text == txtAnswer.text) 
		{
			ProgressBar (1);
			time += addTime;
			goodAns++;

		} else 
		{
			ProgressBar (2);
			time -= subTime;
			badAns++;
		}	
		txtCorrect.text = goodAns.ToString ();
		txtWrong.text = badAns.ToString ();
		AnswerGen ();
	}

	public void BtnFour()
	{
		if (txtBtnNum4.text == txtAnswer.text) 
		{
			ProgressBar (1);
			time += addTime;
			goodAns++;

		} else 
		{
			ProgressBar (2);
			time -= subTime;
			badAns++;
		}
		txtCorrect.text = goodAns.ToString ();
		txtWrong.text = badAns.ToString ();
		AnswerGen ();
	}

	public Image progBar;
	public Image check1;
	public Image check2;
	public Image check3;
	public float progBarAdd = 0.05f;
	public float progBarSub = 0.1f;

	public void ProgressBar(int num)
	{
		if(num == 1)
			progBar.fillAmount += progBarAdd;
		if(num == 2)
			progBar.fillAmount -= progBarSub;

		if (progBar.fillAmount < 0.25f) 
		{
			check1.color = Color.white;
			check2.color = Color.white;
			check2.color = Color.white;
		}
		if (progBar.fillAmount >= 0.25f && progBar.fillAmount < 0.6f) 
		{
			check1.color = Color.green;
			check2.color = Color.white;
			check3.color = Color.white;
		}
		if (progBar.fillAmount >= 0.6f && progBar.fillAmount < 1f) 
		{
			check1.color = Color.green;
			check2.color = Color.green;
			check3.color = Color.white;
		}
		if (progBar.fillAmount >= 1f) 
		{
			check1.color = Color.green;
			check2.color = Color.green;
			check3.color = Color.green;
		}
	}
}
